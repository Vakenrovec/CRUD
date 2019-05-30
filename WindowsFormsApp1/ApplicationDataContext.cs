using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CRUD
{
    public class ApplicationDataContext
    {
        public List<BaseObject> Objects;
        public ComboBox ComboBoxObjects;
        public void ComboBoxObjectsRefresh()
        {
            this.ComboBoxObjects.Items.Clear();
            this.ComboBoxObjects.Items.AddRange(this.Objects.Cast<object>().ToArray());
        }

        public delegate void ObjectCreatedDelegate(List<BaseObject> Objects, BaseObject obj);
        public event ObjectCreatedDelegate ObjectCreatedEvent;
        public void CallObjectCreatedEvent(List<BaseObject> Objects, BaseObject obj)
        {
            if (ObjectCreatedEvent != null)
            {           
                ObjectCreatedEvent(Objects, obj);
            }
        }
        public void AddObjectToList(List<BaseObject> Objects, BaseObject obj)
        {
            Objects.Add(obj);
        }
        public void AddObjectToComboBox(List<BaseObject> Objects, BaseObject obj)
        {
            this.ComboBoxObjects.Items.Add(obj);
        }

        public delegate void ObjectDeletedDelegate(List<BaseObject> Objects, BaseObject obj);
        public event ObjectDeletedDelegate ObjectDeletedEvent;
        public void CallObjectDeletedEvent(List<BaseObject> Objects, BaseObject obj)
        {
            if (ObjectDeletedEvent != null)
            {
                ObjectDeletedEvent(Objects, obj);
            }
        }
        public void DeleteObjectFromList(List<BaseObject> Objects, BaseObject obj)
        {
            Objects.Remove(obj);
        }
        public void DeleteObjectFromComboBox(List<BaseObject> Objects, BaseObject obj)
        {
            this.ComboBoxObjects.Items.Remove(obj);
            this.ComboBoxObjects.Text = "";
        }        
    }
}