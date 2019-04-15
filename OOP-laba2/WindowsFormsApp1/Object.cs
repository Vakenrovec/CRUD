using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApp1
{
    public class LabelAttribute : Attribute
    {
        public string LabelText { get; set; }
        public LabelAttribute(string labelText)
        {
            LabelText = labelText;
        }
    }
    public class CommunicationTypeAttribute : Attribute
    {
        public string CommunicationType { get; set; }
        public CommunicationTypeAttribute(string communicationType)
        {
            CommunicationType = communicationType;
        }
    }
    public class Object
    {
        public virtual void ObjectDeleted(ApplicationDataContext applicationDataContext)
        {

        }           
        private readonly int ControlHeight = 15;
        private readonly int ControlWidth = 150;
        private void GetProperties(Form form, Object obj, ref int y)
        {
            foreach (PropertyInfo property in obj.GetType().GetProperties())
            {
                LabelAttribute attribute = property.GetCustomAttributes(true).OfType<LabelAttribute>().First();
                Controls.AddLabel(form, y, 0, ControlWidth, ControlHeight, attribute.LabelText);
                if (property.PropertyType.IsEnum)
                {
                    Controls.AddComboBox(form, y, ControlWidth, ControlWidth, ControlHeight, property.PropertyType.GetEnumNames(), property.GetValue(obj).ToString());                   
                }
                else
                {
                    Controls.AddTextBox(form, y, ControlWidth, ControlWidth, ControlHeight, property.GetValue(obj)?.ToString());
                }
                y += ControlHeight * 2;
            }
        }
        private void GetFields(Form form, Object obj, ref int y, ApplicationDataContext applicationDataContext)
        {
            foreach (FieldInfo field in obj.GetType().GetFields())
            {
                LabelAttribute attribute = field.GetCustomAttributes(true).OfType<LabelAttribute>().First();
                Controls.AddLabel(form, y, 0, ControlWidth, ControlHeight, attribute.LabelText);
                if (field.FieldType.IsGenericType)
                {
                    IList list = (IList)field.GetValue(obj);
                    Controls.AddComboBox(form, y, ControlWidth, ControlWidth, ControlHeight, list.Cast<object>().ToArray(), "");
                }
                else
                {
                    if (field.FieldType.GetCustomAttributes(true).OfType<CommunicationTypeAttribute>().First().CommunicationType == "Композиция")
                    {
                        Button createObjectButton = Controls.AddButton(form, y, ControlWidth, ControlWidth, ControlHeight, "Посмотреть объект");                       
                        createObjectButton.Click += (sender, e) =>
                        {
                            Object newObj = (Object)field.GetValue(obj);
                            newObj.Update(applicationDataContext, false);
                        };
                    }
                    else
                    {
                        List<Object> list = new List<Object>();
                        foreach (Object element in applicationDataContext.Objects)
                        {
                            if (element.GetType() == field.FieldType && element != field.GetValue(this))
                            {
                                list.Add(element);
                            }
                        }
                        Controls.AddComboBox(form, y, ControlWidth, ControlWidth, ControlHeight, list.Cast<object>().ToArray(), field.GetValue(this));                       
                    }
                }
                y += ControlHeight * 2;
            }
        }
        public void Update(ApplicationDataContext applicationDataContext, bool NeedToCreate)
        {           
            Form form = Controls.AddForm(this, ControlWidth, ControlHeight);
            int y = 0;
            GetProperties(form, this, ref y);
            GetFields(form, this, ref y, applicationDataContext);
            Button saveButton = Controls.AddButton(form, y, 0, ControlWidth, ControlHeight, "Сохранить");
            saveButton.Click += (sender, e) =>
            {
                int i = 1;
                foreach (PropertyInfo property in this.GetType().GetProperties())
                {
                    if (property.PropertyType.IsEnum)
                    {
                        property.SetValue(this, Enum.Parse(property.PropertyType, form.Controls[i].Text));                       
                    }
                    else
                    {
                        property.SetValue(this, Convert.ChangeType(form.Controls[i].Text, property.PropertyType));                        
                    }
                    i += 2;
                }
                foreach (FieldInfo field in this.GetType().GetFields())
                {
                    if (!field.FieldType.IsGenericType && field.FieldType.GetCustomAttributes(true).OfType<CommunicationTypeAttribute>().First().CommunicationType == "Агрегация")
                    {                        
                        ComboBox comboBox = (ComboBox)form.Controls[i];
                        if (comboBox.SelectedItem != null)
                        {
                            if (field.GetValue(this) != null)
                            {
                                foreach (var el in field.FieldType.GetFields())
                                {
                                    if (el.FieldType.IsGenericType)
                                    {
                                        IList list = (IList)el.GetValue(field.GetValue(this));
                                        list.Remove(this);
                                    }
                                }
                            }                           
                            field.SetValue(this, comboBox.SelectedItem);
                            foreach (var el in field.FieldType.GetFields())
                            {
                                if (el.FieldType.IsGenericType)
                                {
                                    IList list = (IList)el.GetValue(comboBox.SelectedItem);
                                    list.Add(this);
                                }
                            }
                        }
                    }                    
                    i += 2;
                }    
                if (NeedToCreate)
                {
                    applicationDataContext.CallObjectCreatedEvent(applicationDataContext.Objects, this);
                }
                applicationDataContext.ComBoxObjectsRefresh();
                form.Close();
            };
            Button cancelButton = Controls.AddButton(form, y, ControlWidth, ControlWidth, ControlHeight, "Отмена");
            cancelButton.Click += (sender, e) =>
            {
                form.Close();
            };
            form.Show();
        }
    }   
}