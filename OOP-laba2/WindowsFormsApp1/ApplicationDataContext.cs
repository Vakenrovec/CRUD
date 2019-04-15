using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class ApplicationDataContext
    {
        public List<Object> Objects;
        public ComboBox ComboBoxObjects;
        public void ComBoxObjectsRefresh()
        {
            this.ComboBoxObjects.Items.Clear();
            this.ComboBoxObjects.Items.AddRange(this.Objects.Cast<object>().ToArray());
        }

        public delegate void ObjectCreatedDelegate(List<Object> Objects, Object obj);
        public event ObjectCreatedDelegate ObjectCreatedEvent;
        public void CallObjectCreatedEvent(List<Object> Objects, Object obj)
        {
            if (ObjectCreatedEvent != null)
            {           
                ObjectCreatedEvent(Objects, obj);
            }
        }
        public void AddObjectToList(List<Object> Objects, Object obj)
        {
            Objects.Add(obj);
        }
        public void AddObjectToComboBox(List<Object> Objects, Object obj)
        {
            this.ComboBoxObjects.Items.Add(obj);
        }

        public delegate void ObjectDeletedDelegate(List<Object> Objects, Object obj);
        public event ObjectDeletedDelegate ObjectDeletedEvent;
        public void CallObjectDeletedEvent(List<Object> Objects, Object obj)
        {
            if (ObjectDeletedEvent != null)
            {
                ObjectDeletedEvent(Objects, obj);
            }
        }
        public void DeleteObjectFromList(List<Object> Objects, Object obj)
        {
            Objects.Remove(obj);
        }
        public void DeleteObjectFromComboBox(List<Object> Objects, Object obj)
        {
            this.ComboBoxObjects.Items.Remove(obj);
            this.ComboBoxObjects.Text = "";
        }
    }
}