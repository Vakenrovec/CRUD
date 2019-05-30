using CodingPluginInterface;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CRUD
{
    public partial class FormMain : Form
    {       
        public FormMain()
        {
            InitializeComponent();
        }
        public ApplicationDataContext applicationDataContext;    
        private void FormMain_Load(object sender, EventArgs e)
        {
            applicationDataContext = new ApplicationDataContext()
            {
                Objects = new List<BaseObject>(),
                ComboBoxObjects = ComboBoxObjects,
            };
            applicationDataContext.ObjectCreatedEvent += applicationDataContext.AddObjectToList;
            applicationDataContext.ObjectCreatedEvent += applicationDataContext.AddObjectToComboBox;
            applicationDataContext.ObjectDeletedEvent += applicationDataContext.DeleteObjectFromList;
            applicationDataContext.ObjectDeletedEvent += applicationDataContext.DeleteObjectFromComboBox;

            IFactory[] ArrayOfFactories = new IFactory[] {
                new FlattopFactory("Авианосец"),
                new WarPlaneFactory("Военный самолет"),
                new PilotFactory("Пилот"),
            };
            ComboBoxCreate.Items.AddRange(ArrayOfFactories);

            CreateObject createObject = new CreateObject();
            createObject.CreateSomeObjects(applicationDataContext);

            SerializerFactory[] ArrayOfSerializers = new SerializerFactory[] {
                new JsonFactory("Json"),
                new BinaryFactory("Бинарная"),
                new ClientFactory("Клиентская"),
            };
            ComboBoxSerializers.Items.AddRange(ArrayOfSerializers);

            CodingPlugins codePlugins = new CodingPlugins();
            codePlugins.RefreshPlugins();
            ComboBoxCoders.Items.AddRange(codePlugins.plugins.ToArray());
        }
        private void ComboBoxCreate_SelectionChangeCommitted(object sender, EventArgs e)
        {
            IFactory factory = (IFactory)ComboBoxCreate.SelectedItem;
            BaseObject obj = factory.CreateObject();
            obj.Update(applicationDataContext, true);
        }
        private void ButtonDeleteObject_Click(object sender, EventArgs e)
        {
            BaseObject selectedItem = (BaseObject)this.ComboBoxObjects.SelectedItem;
            selectedItem.ObjectDeleted(applicationDataContext);
            applicationDataContext.CallObjectDeletedEvent(applicationDataContext.Objects, selectedItem);
        }
        private void ButtonUpdateObject_Click(object sender, EventArgs e)
        {
            BaseObject selectedItem = (BaseObject)this.ComboBoxObjects.SelectedItem;
            selectedItem.Update(applicationDataContext, false);
        }

        private void ButtonSaveSerializedObjects_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = SaveFileDialog.FileName;

                SerializerFactory factory = (SerializerFactory)ComboBoxSerializers.SelectedItem;
                ISerializer serializer = factory.CreateSerializer();
                string serializedObjects = serializer.Serialize(applicationDataContext.Objects);
                fileName += factory.Extension;

                if (CheckBoxCoder.Checked)
                {
                    ICodingPlugin plugin = (ICodingPlugin)ComboBoxCoders.SelectedItem;
                    serializedObjects = plugin.Code(Encoding.UTF8.GetBytes(serializedObjects));
                    fileName += plugin.Extension;
                }

                File.WriteAllText(SaveFileDialog.FileName, serializedObjects);
                File.Move(SaveFileDialog.FileName, fileName);
            }
        }
        private void ButtonDownloadDeserializedObjects_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = OpenFileDialog.FileName;
                string serializedObjects = File.ReadAllText(OpenFileDialog.FileName);
                for (int i = 0; i < ComboBoxCoders.Items.Count; i++)
                {
                    ICodingPlugin plugin = (ICodingPlugin)ComboBoxCoders.Items[i];
                    if (plugin.Extension == fileName.Substring(fileName.LastIndexOf(".")))
                    {                        
                        serializedObjects = Encoding.UTF8.GetString(plugin.Decode(serializedObjects));                        
                        fileName = fileName.Substring(0, fileName.LastIndexOf("."));
                    }
                }
                for (int i = 0; i < ComboBoxSerializers.Items.Count; i++)
                {
                    SerializerFactory factory = (SerializerFactory)ComboBoxSerializers.Items[i];
                    if (factory.Extension == fileName.Substring(fileName.LastIndexOf(".")))
                    {                                               
                        ISerializer serializer = factory.CreateSerializer();
                        applicationDataContext.Objects = serializer.Deserialize(serializedObjects);
                        applicationDataContext.ComboBoxObjectsRefresh();
                        return;
                    }
                }
                MessageBox.Show("Сериализатора или плагина с таким расширением не найдено(");
            }
        }
    }
}
