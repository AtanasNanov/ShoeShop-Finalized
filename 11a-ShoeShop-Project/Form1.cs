using _11a_ShoeShop_Project.Controller;
using _11a_ShoeShop_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11a_ShoeShop_Project
{
    public partial class Form1 : Form
    {
        ShoeBusiness shoeBusiness = new ShoeBusiness();
        ShoeTypeBusiness shoeTypeBusiness = new ShoeTypeBusiness();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Shoe shoe)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = shoe.Id.ToString();
            textBox2.Text = shoe.Brand;
            textBox3.Text = shoe.Price.ToString();
            textBox4.Text = shoe.ShoeSize.ToString();
            textBox5.Text = shoe.Description.ToString();
            comboBox1.Text = shoe.ShoeType.Name;
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<ShoeType> allTypes = shoeTypeBusiness.GetAllTypes();
            comboBox1.DataSource = allTypes;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Въведете марка!");
                return;
            }
            Shoe shoe = new Shoe();
            shoe.Brand = textBox2.Text;
            shoe.Description = textBox5.Text;
            shoe.Price = decimal.Parse(textBox3.Text);
            shoe.ShoeSize = int.Parse(textBox4.Text);
            shoe.ShoeTypeId = (int)comboBox1.SelectedValue;
            shoeBusiness.Add(shoe);
            ClearScreen();
        }

        private void getAllButton_Click(object sender, EventArgs e)
        {
            List<Shoe> shoes = shoeBusiness.GetAll();
            listBox1.Items.Clear();

            foreach (var item in shoes)
            {
                listBox1.Items.Add($"{item.Id} Марка: {item.Brand} Цена: {item.Price}BGN Размер:{item.ShoeSize} Описание:{item.Description} Тип: {item.ShoeType.Name}");
            }
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи ID за търсене!");
                textBox1.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(textBox1.Text);
            }
            Shoe shoe1 = shoeBusiness.Get(id);
            if (shoe1 == null)
            {
                MessageBox.Show("Няма такава обувка в базата! \n Въведи ID.");
                textBox1.BackColor = Color.Red;
                return;
            }
            LoadRecord(shoe1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи ID за търсене!");
                textBox1.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(textBox1.Text);
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Shoe shoe1 = shoeBusiness.Get(id);
                if (shoe1 == null)
                {
                    MessageBox.Show("Няма такава обувка в базата! \n Въведи ID.");
                    textBox1.BackColor = Color.Red;
                    return;
                }
                LoadRecord(shoe1);
            }
            else
            {
                Shoe shoe2 = new Shoe();
                shoe2.Brand = textBox2.Text;
                shoe2.Price= decimal.Parse(textBox3.Text);
                shoe2.ShoeSize = int.Parse(textBox4.Text);
                shoe2.Description = textBox5.Text;
                shoe2.ShoeTypeId = (int)comboBox1.SelectedValue;
                shoeBusiness.Update(id, shoe2);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи ID за триене!");
                textBox1.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(textBox1.Text);
            }
            Shoe shoe1 = shoeBusiness.Get(id);
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                if (shoe1 == null)
                {
                    MessageBox.Show("Няма такава обувка в базата! \n Въведи ID.");
                    textBox1.BackColor = Color.Red;
                    return;
                }
            }
            LoadRecord(shoe1);

            DialogResult delete = MessageBox.Show("Искате ли да изтриете обувката?", "Delete", MessageBoxButtons.YesNo);
            if (delete == DialogResult.Yes)
            {
                shoeBusiness.Delete(id);
            }
        }
    }
}
