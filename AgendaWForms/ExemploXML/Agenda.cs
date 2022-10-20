using System;
using System.Windows.Forms;
using System.Xml;

namespace ExemploXML
{
    public partial class FrmAgenda : Form
    {
        public FrmAgenda()
        {
            InitializeComponent();
        }

        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            AtualizarDados();
        }

        private void AtualizarDados()
        {
            LimparCampos();
            //instanciando o método dentro do Título
            lblTitulo.Text = CarregaTitulo();
            //instanciando o método para carregar os contatos
            CarregarContatos();
        }

        private void LimparCampos()
        {
            lblTitulo.Text = string.Empty;
            lbxContatos.Items.Clear();
        }

        //este método vai fazer a abertura do xml e pegar o conteúdo da tag título
        private string CarregaTitulo()
        {
            //XmlDocument é uma classe usanda para abrir o xml é um documento xml
            XmlDocument documentoXml = new XmlDocument();
            //método load irá carregar o arquivo xml dentro do document, colocando o caminho de onde está salvo seu agenda.xml
            documentoXml.Load(@"C:\Users\Andre\Desktop\Semana3AndreCanuto\AgendaWForms\ExemploXML\Agenda.xml");
            //selecionar o nó usando o XmlNode , SelectSingleNode que permite selecionar um determinado nó
            XmlNode noTitulo = documentoXml.SelectSingleNode("/agenda/titulo");
            //retorna o conteúdo do texto do nó titulo com InnerText
            return noTitulo.InnerText;
        }

        //método usado para carregar os dados da agenda
        private void CarregarContatos()
        {
            //XmlDocument é uma classe usada para abrir o xml
            XmlDocument documentoXml = new XmlDocument();
            //método load irá carregar o arquivo xml dentro do document, colocando o caminho de onde está salvo seu agenda.xml
            documentoXml.Load(@"C:\Users\Andre\Desktop\Semana3AndreCanuto\AgendaWForms\ExemploXML\Agenda.xml");
            //classe XmlNodeList que irá retornar todos os itens do nó.
            XmlNodeList contatos = documentoXml.SelectNodes("/agenda/clientes/cliente");
            //usado para preencher a listbox com os contatos que está no xml
            foreach (XmlNode agenda in contatos)
            {
                //pegar as informações dos atributos
                string representacaoContatos = "";//irá começar com vazio 14
                string id = agenda.Attributes["id"].Value;
                string nome = agenda.Attributes["nome"].Value;
                string idade = agenda.Attributes["idade"].Value;
                representacaoContatos = id + " , " + nome + " , " + idade;
                lbxContatos.Items.Add(representacaoContatos);
            }
        }

        private void CriarContato()
        {
            XmlDocument documentoXml = new XmlDocument();
            documentoXml.Load(@"C:\Users\Andre\Desktop\Semana3AndreCanuto\AgendaWForms\ExemploXML\Agenda.xml");

            //criar um novo contato
            XmlAttribute atributoId = documentoXml.CreateAttribute("id");
            atributoId.Value = "5";
            XmlAttribute atributoNome = documentoXml.CreateAttribute("nome");
            atributoNome.Value = "Sonia Regina";
            XmlAttribute atributoIdade = documentoXml.CreateAttribute("idade");
            atributoIdade.Value = "60";
            //será usado para inserir a nova linha no arquivo Xml
            XmlNode novoContato = documentoXml.CreateElement("cliente");
            //vincular os atributos ao no xml
            novoContato.Attributes.Append(atributoId);
            novoContato.Attributes.Append(atributoNome);
            novoContato.Attributes.Append(atributoIdade);
            //vincular ao no clientes
            XmlNode contatos = documentoXml.SelectSingleNode("/agenda/clientes");
            //adicionar um filho ao no clientes
            contatos.AppendChild(novoContato);
            //salvar no arquivo xml especificado na lina abaixo 15
            documentoXml.Save(@"C:\Users\Andre\Desktop\Semana3AndreCanuto\AgendaWForms\ExemploXML\Agenda.xml");
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CriarContato();
            AtualizarDados();
        }
    }
}
