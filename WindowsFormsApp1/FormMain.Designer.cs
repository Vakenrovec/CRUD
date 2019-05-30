namespace CRUD
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboBoxCreate = new System.Windows.Forms.ComboBox();
            this.ComboBoxObjects = new System.Windows.Forms.ComboBox();
            this.LabelObjects = new System.Windows.Forms.Label();
            this.LabelCreate = new System.Windows.Forms.Label();
            this.ButtonUpdateObject = new System.Windows.Forms.Button();
            this.ButtonDeleteObject = new System.Windows.Forms.Button();
            this.ComboBoxSerializers = new System.Windows.Forms.ComboBox();
            this.LabelSerializer = new System.Windows.Forms.Label();
            this.ButtonSaveSerializedObjects = new System.Windows.Forms.Button();
            this.ButtonDownloadDeserializedObjects = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ComboBoxCoders = new System.Windows.Forms.ComboBox();
            this.LabelCoder = new System.Windows.Forms.Label();
            this.CheckBoxCoder = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ComboBoxCreate
            // 
            this.ComboBoxCreate.FormattingEnabled = true;
            this.ComboBoxCreate.Location = new System.Drawing.Point(27, 166);
            this.ComboBoxCreate.Name = "ComboBoxCreate";
            this.ComboBoxCreate.Size = new System.Drawing.Size(226, 24);
            this.ComboBoxCreate.TabIndex = 0;
            this.ComboBoxCreate.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxCreate_SelectionChangeCommitted);
            // 
            // ComboBoxObjects
            // 
            this.ComboBoxObjects.FormattingEnabled = true;
            this.ComboBoxObjects.Location = new System.Drawing.Point(27, 42);
            this.ComboBoxObjects.Name = "ComboBoxObjects";
            this.ComboBoxObjects.Size = new System.Drawing.Size(226, 24);
            this.ComboBoxObjects.TabIndex = 3;
            // 
            // LabelObjects
            // 
            this.LabelObjects.AutoSize = true;
            this.LabelObjects.Location = new System.Drawing.Point(24, 22);
            this.LabelObjects.Name = "LabelObjects";
            this.LabelObjects.Size = new System.Drawing.Size(137, 17);
            this.LabelObjects.TabIndex = 4;
            this.LabelObjects.Text = "Все объекты здесь!";
            // 
            // LabelCreate
            // 
            this.LabelCreate.AutoSize = true;
            this.LabelCreate.Location = new System.Drawing.Point(24, 146);
            this.LabelCreate.Name = "LabelCreate";
            this.LabelCreate.Size = new System.Drawing.Size(121, 17);
            this.LabelCreate.TabIndex = 5;
            this.LabelCreate.Text = "Создать объект?";
            // 
            // ButtonUpdateObject
            // 
            this.ButtonUpdateObject.Location = new System.Drawing.Point(27, 72);
            this.ButtonUpdateObject.Name = "ButtonUpdateObject";
            this.ButtonUpdateObject.Size = new System.Drawing.Size(134, 23);
            this.ButtonUpdateObject.TabIndex = 6;
            this.ButtonUpdateObject.Text = "Редактировать";
            this.ButtonUpdateObject.UseVisualStyleBackColor = true;
            this.ButtonUpdateObject.Click += new System.EventHandler(this.ButtonUpdateObject_Click);
            // 
            // ButtonDeleteObject
            // 
            this.ButtonDeleteObject.Location = new System.Drawing.Point(167, 72);
            this.ButtonDeleteObject.Name = "ButtonDeleteObject";
            this.ButtonDeleteObject.Size = new System.Drawing.Size(86, 23);
            this.ButtonDeleteObject.TabIndex = 7;
            this.ButtonDeleteObject.Text = "Удалить";
            this.ButtonDeleteObject.UseVisualStyleBackColor = true;
            this.ButtonDeleteObject.Click += new System.EventHandler(this.ButtonDeleteObject_Click);
            // 
            // ComboBoxSerializers
            // 
            this.ComboBoxSerializers.FormattingEnabled = true;
            this.ComboBoxSerializers.Location = new System.Drawing.Point(27, 260);
            this.ComboBoxSerializers.Name = "ComboBoxSerializers";
            this.ComboBoxSerializers.Size = new System.Drawing.Size(229, 24);
            this.ComboBoxSerializers.TabIndex = 8;
            // 
            // LabelSerializer
            // 
            this.LabelSerializer.AutoSize = true;
            this.LabelSerializer.Location = new System.Drawing.Point(24, 240);
            this.LabelSerializer.Name = "LabelSerializer";
            this.LabelSerializer.Size = new System.Drawing.Size(171, 17);
            this.LabelSerializer.TabIndex = 9;
            this.LabelSerializer.Text = "Выберите сериализатор";
            // 
            // ButtonSaveSerializedObjects
            // 
            this.ButtonSaveSerializedObjects.Location = new System.Drawing.Point(27, 374);
            this.ButtonSaveSerializedObjects.Name = "ButtonSaveSerializedObjects";
            this.ButtonSaveSerializedObjects.Size = new System.Drawing.Size(108, 23);
            this.ButtonSaveSerializedObjects.TabIndex = 10;
            this.ButtonSaveSerializedObjects.Text = "Сохранить";
            this.ButtonSaveSerializedObjects.UseVisualStyleBackColor = true;
            this.ButtonSaveSerializedObjects.Click += new System.EventHandler(this.ButtonSaveSerializedObjects_Click);
            // 
            // ButtonDownloadDeserializedObjects
            // 
            this.ButtonDownloadDeserializedObjects.Location = new System.Drawing.Point(141, 374);
            this.ButtonDownloadDeserializedObjects.Name = "ButtonDownloadDeserializedObjects";
            this.ButtonDownloadDeserializedObjects.Size = new System.Drawing.Size(115, 23);
            this.ButtonDownloadDeserializedObjects.TabIndex = 11;
            this.ButtonDownloadDeserializedObjects.Text = "Загрузить";
            this.ButtonDownloadDeserializedObjects.UseVisualStyleBackColor = true;
            this.ButtonDownloadDeserializedObjects.Click += new System.EventHandler(this.ButtonDownloadDeserializedObjects_Click);
            // 
            // ComboBoxCoders
            // 
            this.ComboBoxCoders.FormattingEnabled = true;
            this.ComboBoxCoders.Location = new System.Drawing.Point(27, 317);
            this.ComboBoxCoders.Name = "ComboBoxCoders";
            this.ComboBoxCoders.Size = new System.Drawing.Size(229, 24);
            this.ComboBoxCoders.TabIndex = 12;
            // 
            // LabelCoder
            // 
            this.LabelCoder.AutoSize = true;
            this.LabelCoder.Location = new System.Drawing.Point(24, 297);
            this.LabelCoder.Name = "LabelCoder";
            this.LabelCoder.Size = new System.Drawing.Size(162, 17);
            this.LabelCoder.TabIndex = 13;
            this.LabelCoder.Text = "Выберете кодировщик ";
            // 
            // CheckBoxCoder
            // 
            this.CheckBoxCoder.AutoSize = true;
            this.CheckBoxCoder.Checked = true;
            this.CheckBoxCoder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxCoder.Location = new System.Drawing.Point(27, 347);
            this.CheckBoxCoder.Name = "CheckBoxCoder";
            this.CheckBoxCoder.Size = new System.Drawing.Size(184, 21);
            this.CheckBoxCoder.TabIndex = 14;
            this.CheckBoxCoder.Text = "Нужен ли кодировщик?";
            this.CheckBoxCoder.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 426);
            this.Controls.Add(this.CheckBoxCoder);
            this.Controls.Add(this.LabelCoder);
            this.Controls.Add(this.ComboBoxCoders);
            this.Controls.Add(this.ButtonDownloadDeserializedObjects);
            this.Controls.Add(this.ButtonSaveSerializedObjects);
            this.Controls.Add(this.LabelSerializer);
            this.Controls.Add(this.ComboBoxSerializers);
            this.Controls.Add(this.ButtonDeleteObject);
            this.Controls.Add(this.ButtonUpdateObject);
            this.Controls.Add(this.LabelCreate);
            this.Controls.Add(this.LabelObjects);
            this.Controls.Add(this.ComboBoxObjects);
            this.Controls.Add(this.ComboBoxCreate);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRUD";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxCreate;
        public System.Windows.Forms.ComboBox ComboBoxObjects;
        private System.Windows.Forms.Label LabelObjects;
        private System.Windows.Forms.Label LabelCreate;
        private System.Windows.Forms.Button ButtonUpdateObject;
        private System.Windows.Forms.Button ButtonDeleteObject;
        private System.Windows.Forms.ComboBox ComboBoxSerializers;
        private System.Windows.Forms.Label LabelSerializer;
        private System.Windows.Forms.Button ButtonSaveSerializedObjects;
        private System.Windows.Forms.Button ButtonDownloadDeserializedObjects;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.ComboBox ComboBoxCoders;
        private System.Windows.Forms.Label LabelCoder;
        private System.Windows.Forms.CheckBox CheckBoxCoder;
    }
}

