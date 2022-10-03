using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfNumbers
{
    public partial class NewGame_Form : Form
    {
        public Player[] Result => _result;
        public void ClearResult()
        {
            _result = null;
        }

        private Player[] _result;
        private readonly string[]  _type_names;
        private readonly ComboBox[] _types;
        private readonly TextBox[] _names;

        public NewGame_Form()
        {
            InitializeComponent();
            _type_names = new string[] { Player_Type.Human.ToString(), Player_Type.NeuralNet.ToString(), Player_Type.Random.ToString() };
            _types = new ComboBox[] { Type_CB1, Type_CB2, Type_CB3, Type_CB4 };
            _names = new TextBox[] { Name_TB1, Name_TB2, Name_TB3, Name_TB4 };
            foreach (var cb in _types)
            {
                cb.Text = _type_names[2];
                cb.Items.AddRange(_type_names);
            }
        }

        private Player GetPlayer(int id)
        {
            if (_types[id].Text == Player_Type.Human.ToString())
                return new Human_Player(_names[id].Text);
            if (_types[id].Text == Player_Type.NeuralNet.ToString())
                return NeuralNetwork_Player.From_File(name: _names[id].Text, index: id);
            if (_types[id].Text == Player_Type.Random.ToString())
                return new Random_Player(_names[id].Text);
            throw new Exception("Wrond Type!");
        }

        private bool Types_Is_Valid() => _types.All(t => _type_names.Contains(t.Text));
        private bool Names_Is_Valid() => _names.All(n => n.Text != "");
        private void button1_Click(object sender, EventArgs e)
        {
            if (Types_Is_Valid() == false || Names_Is_Valid() == false)
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }

            _result = new Player[4];
            for (int i = 0; i < 4; i++)
            {
                _result[i] = GetPlayer(i);
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
