﻿using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using MaterialSkin;

namespace PresentationLayer.AddForms
{
    public partial class AddClient : Form
    {
        private readonly IClientService _clientService;
        private readonly ClientCodeGenerator _clientCodeGenerator;
        public AddClient()
        {
            _clientCodeGenerator = new ClientCodeGenerator();
            _clientService = new ClientServices();
            InitializeComponent();
        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            LoadListBoxView();
        }

        private void LoadListBoxView()
        {
            var data = _clientService.GetAllCLientName();
            codigoTxt.Texts = _clientCodeGenerator.ClientCode();
            // Single Line
            foreach (var name in data)
            {
                MaterialListBoxItem item = new();
                item.Text = name;
                materialListBox1.Items.Add(item);
                // If i want to add a secondary text the code must be: item.SecondaryText = data and the add still equal
            }
        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            ClientDTO clientDTO = new()
            {
                ClientName = nombreTxt.Texts,
                Address = direccionTxt.Texts,
                City = ciudadTxt.Texts,
                Email = emailTxt.Texts,
                PhoneNumber = telefonoTxt.Texts,
                Fax = faxTxt.Texts,
                Rnc = rncTxt.Texts,
                Code = Convert.ToInt32(codigoTxt.Texts)
            };
            _clientService.AddClient(clientDTO);
            // Adding to the list Box
            materialListBox1.Items.Clear();
            LoadListBoxView();
            CleanTextBox();
            MessageBox.Show("Cliente agregado correctamente");
        }

        private void CleanTextBox()
        {
            nombreTxt.Texts = "";
            direccionTxt.Texts = "";
            ciudadTxt.Texts = "";
            emailTxt.Texts = "";
            telefonoTxt.Texts = "";
            faxTxt.Texts = "";
            rncTxt.Texts = "";
            codigoTxt.Texts = _clientCodeGenerator.ClientCode();
        }
    }
}
