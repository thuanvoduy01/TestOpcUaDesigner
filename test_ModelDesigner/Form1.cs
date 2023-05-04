using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace test_ModelDesigner
{
    public partial class Form1 : Form
    {
        public readonly static string MODEL_DESIGN_UC_DIRECTORY = @"D:\Proj\VStudio\Test_OpcUaDesigner\test_ModelDesigner\ModelDesign.xml";
        string xmlModelDesignUcDir = MODEL_DESIGN_UC_DIRECTORY;

        public Form1()
        {
            InitializeComponent();

            InitDesignerUcMdoel();
        }

        public void InitDesignerUcMdoel()
        {
            #region create an empty model design file (using DesignerUcModel.xml)
            // Open the file in write mode and write an empty string to it
            // If the file not exist, StreamWriter will create a new one
            using (StreamWriter sw = new StreamWriter(xmlModelDesignUcDir, false))
            {
                sw.Write(String.Empty);
            }
            #endregion

            #region Add tag to the empty file to create a normative file
            //The normaive file look like this:
            /*      
                   <?xml version="1.0" encoding="utf-8"?>
                   <opc:ModelDesign xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                                     xmlns:xsd="http://www.w3.org/2001/XMLSchema"
                                     xmlns:opc="http://opcfoundation.org/UA/ModelDesign.xsd"
                                     xmlns:ua="http://opcfoundation.org/UA/"
                                     xmlns:uax="http://opcfoundation.org/UA/2008/02/Types.xsd"
                                     xmlns="http://opcfoundation.org/OPCUAServer"
                                     TargetNamespace="http://opcfoundation.org/OPCUAServer">
	                    <opc:Namespaces>
		                    <opc:Namespace Name="OpcUa"
		                                   Prefix="Opc.Ua"
		                                   XmlNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd">http://opcfoundation.org/UA/</opc:Namespace>
		                    <opc:Namespace Name="MyOPCUAServer"
		                                   Prefix="MyOPCUAServer">http://opcfoundation.org/OPCUAServer</opc:Namespace>
	                    </opc:Namespaces>
                        <!-- Model is added here -->
                    </opc:ModelDesign>
                
            */

            // Create the XML document instance
            XmlDocument xmlDoc = new XmlDocument();

            #region Create the <?xml version="1.0" encoding="utf-8" ?> declaration
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDeclaration);
            #endregion

            #region Create the <opc:ModelDesign> element (root element)
            XmlElement modelDesignElement = xmlDoc.CreateElement("opc", "ModelDesign", "http://opcfoundation.org/UA/ModelDesign.xsd");
            xmlDoc.AppendChild(modelDesignElement);
            #endregion

            #region Add the xmlns attributes to the <opc:ModelDesign> element
            modelDesignElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            modelDesignElement.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            modelDesignElement.SetAttribute("xmlns:opc", "http://opcfoundation.org/UA/ModelDesign.xsd");
            modelDesignElement.SetAttribute("xmlns:ua", "http://opcfoundation.org/UA/");
            modelDesignElement.SetAttribute("xmlns:uax", "http://opcfoundation.org/UA/2008/02/Types.xsd");
            modelDesignElement.SetAttribute("xmlns", "http://opcfoundation.org/OPCUAServer");
            modelDesignElement.SetAttribute("TargetNamespace", "http://opcfoundation.org/OPCUAServer");
            #endregion

            #region Add namespace to the <opc:ModelDesign> element
            // Create the <opc:Namespaces> element
            XmlElement namespacesElement = xmlDoc.CreateElement("opc", "Namespaces", "http://opcfoundation.org/UA/ModelDesign.xsd");
            modelDesignElement.AppendChild(namespacesElement);

            // Create the <opc:Namespace> elements and add them to the <opc:Namespaces> element
            XmlElement namespaceElement1 = xmlDoc.CreateElement("opc", "Namespace", "http://opcfoundation.org/UA/ModelDesign.xsd");
            namespaceElement1.SetAttribute("Name", "OpcUa");
            namespaceElement1.SetAttribute("Prefix", "Opc.Ua");
            namespaceElement1.SetAttribute("XmlNamespace", "http://opcfoundation.org/UA/2008/02/Types.xsd");
            namespaceElement1.InnerText = "http://opcfoundation.org/UA/";
            namespacesElement.AppendChild(namespaceElement1);

            XmlElement namespaceElement2 = xmlDoc.CreateElement("opc", "Namespace", "http://opcfoundation.org/UA/ModelDesign.xsd");
            namespaceElement2.SetAttribute("Name", "MyOPCUAServer");
            namespaceElement2.SetAttribute("Prefix", "MyOPCUAServer");
            namespaceElement2.InnerText = "http://opcfoundation.org/OPCUAServer";
            namespacesElement.AppendChild(namespaceElement2);
            #endregion

            xmlDoc.Save(xmlModelDesignUcDir);
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            #region load xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlModelDesignUcDir);
            #endregion

            #region Determine where to add
            //tạm thời insert vào cuối file
            XmlElement root = xmlDocument.DocumentElement;
            XmlElement parent = root;
            if (txtDesType.Text != String.Empty && txtDesName.Text != String.Empty)
            {
                parent = GetXmlChildren(parent, txtDesType.Text, txtDesName.Text);
            }

            //Check if destination exist
            if (parent == null)
            {
                MessageBox.Show("Can not find where to add");
                return;
            }
            #endregion

            #region Create xml tag for folder
            bool isChildOfModelDesign = false;

            XmlElement folderElement = xmlDocument.CreateElement("opc", "Object", "http://opcfoundation.org/UA/ModelDesign.xsd");
            folderElement.SetAttribute("SymbolicName", txtSymbolicName.Text);
            folderElement.SetAttribute("TypeDefinition", "ua:FolderType");

            XmlElement childrenElement = xmlDocument.CreateElement("opc", "Children", "http://opcfoundation.org/UA/ModelDesign.xsd");
            folderElement.AppendChild(childrenElement);
            XmlElement referencesElement = xmlDocument.CreateElement("opc", "References", "http://opcfoundation.org/UA/ModelDesign.xsd");
            folderElement.AppendChild(referencesElement);

            if (parent.Name.Contains("ModelDesign"))
            {
                isChildOfModelDesign = true;
            }

            if (isChildOfModelDesign)
            {
                /*
                 Create Reference tag
                    <opc:Reference IsInverse="true">
                        <opc:ReferenceType>ua:Organizes</opc:ReferenceType>
                        <opc:TargetId>ua:ObjectsFolder</opc:TargetId>
                     </opc:Reference>
                 */
                XmlElement referenceElement = xmlDocument.CreateElement("opc", "Reference", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceElement.SetAttribute("IsInverse", "true");
                referencesElement.AppendChild(referenceElement);

                XmlElement referenceTypeElement = xmlDocument.CreateElement("opc", "ReferenceType", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceTypeElement.InnerText = "ua:Organizes";
                referenceElement.AppendChild(referenceTypeElement);
                XmlElement targetIdElement = xmlDocument.CreateElement("opc", "TargetId", "http://opcfoundation.org/UA/ModelDesign.xsd");
                targetIdElement.InnerText = "ua:ObjectsFolder";
                referenceElement.AppendChild(targetIdElement);
            }
            #endregion


            
            parent.AppendChild(folderElement);

            xmlDocument.Save(xmlModelDesignUcDir);
        }

        private void btnAddObject_Click(object sender, EventArgs e)
        {

            #region load xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlModelDesignUcDir);
            #endregion

            #region Determine where to add
            
            XmlElement root = xmlDocument.DocumentElement;
            XmlElement parent = root;
            if (txtDesType.Text != String.Empty && txtDesName.Text != String.Empty)
            {
                parent = GetXmlChildren(parent, txtDesType.Text, txtDesName.Text);
            }

            //Check if destination exist
            if (parent == null)
            {
                MessageBox.Show("Can not find where to add");
                return;
            }
            #endregion


            bool isChildOfModelDesign = true;
            if (parent.Name.Contains("ModelDesign") == false)
            {
                isChildOfModelDesign = false;

                parent = GotoChildrenElement(parent);
                //can add check null of parent here but not necessary
                //cause if it isn't ModelDesign, it suppose to have <opc:Children>
            }
            else{}

            #region Create xml tag for object
            XmlElement objectElement = xmlDocument.CreateElement("opc", "Object", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.SetAttribute("SymbolicName", txtSymbolicName.Text);
            objectElement.SetAttribute("TypeDefinition", "ua:BaseObjectType");

            XmlElement childrenElement = xmlDocument.CreateElement("opc", "Children", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.AppendChild(childrenElement);
            XmlElement referencesElement = xmlDocument.CreateElement("opc", "References", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.AppendChild(referencesElement);

            if (isChildOfModelDesign)
            {
                /*
                 Create Reference tag
                    <opc:Reference IsInverse="true">
                        <opc:ReferenceType>ua:Organizes</opc:ReferenceType>
                        <opc:TargetId>ua:ObjectsFolder</opc:TargetId>
                     </opc:Reference>
                 */
                XmlElement referenceElement = xmlDocument.CreateElement("opc", "Reference", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceElement.SetAttribute("IsInverse", "true");
                referencesElement.AppendChild(referenceElement);

                XmlElement referenceTypeElement = xmlDocument.CreateElement("opc", "ReferenceType", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceTypeElement.InnerText = "ua:Organizes";
                referenceElement.AppendChild(referenceTypeElement);
                XmlElement targetIdElement = xmlDocument.CreateElement("opc", "TargetId", "http://opcfoundation.org/UA/ModelDesign.xsd");
                targetIdElement.InnerText = "ua:ObjectsFolder";
                referenceElement.AppendChild(targetIdElement);
            }
            #endregion

            parent.AppendChild(objectElement);

            xmlDocument.Save(xmlModelDesignUcDir);
        }

        private void btnAddVariable_Click(object sender, EventArgs e)
        {
            #region load xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlModelDesignUcDir);
            #endregion

            #region Determine where to add
            XmlElement root = xmlDocument.DocumentElement;
            XmlElement parent = root;
            if (txtDesType.Text != String.Empty && txtDesName.Text != String.Empty)
            {
                parent = GetXmlChildren(parent, txtDesType.Text, txtDesName.Text);
            }

            //Check if destination exist
            if (parent == null)
            {
                MessageBox.Show("Can not find where to add");
                return;
            }
            #endregion


            bool isChildOfModelDesign = true;
            if (parent.Name.Contains("ModelDesign") == false)
            {
                isChildOfModelDesign = false;

                parent = GotoChildrenElement(parent);
                //can add check null of parent here but not necessary
                //cause if it isn't ModelDesign, it suppose to have <opc:Children>
            }
            else { }

            #region Create xml tag for object
            XmlElement variableElement = xmlDocument.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", txtSymbolicName.Text);
            variableElement.SetAttribute("DataType", "ua:Double");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");

            XmlElement childrenElement = xmlDocument.CreateElement("opc", "Children", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.AppendChild(childrenElement);
            XmlElement referencesElement = xmlDocument.CreateElement("opc", "References", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.AppendChild(referencesElement);

            if (isChildOfModelDesign)
            {
                /*
                 Create Reference tag
                    <opc:Reference IsInverse="true">
                        <opc:ReferenceType>ua:Organizes</opc:ReferenceType>
                        <opc:TargetId>ua:ObjectsFolder</opc:TargetId>
                     </opc:Reference>
                 */
                XmlElement referenceElement = xmlDocument.CreateElement("opc", "Reference", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceElement.SetAttribute("IsInverse", "true");
                referencesElement.AppendChild(referenceElement);

                XmlElement referenceTypeElement = xmlDocument.CreateElement("opc", "ReferenceType", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceTypeElement.InnerText = "ua:Organizes";
                referenceElement.AppendChild(referenceTypeElement);
                XmlElement targetIdElement = xmlDocument.CreateElement("opc", "TargetId", "http://opcfoundation.org/UA/ModelDesign.xsd");
                targetIdElement.InnerText = "ua:ObjectsFolder";
                referenceElement.AppendChild(targetIdElement);
            }
            #endregion

            parent.AppendChild(variableElement);

            xmlDocument.Save(xmlModelDesignUcDir);
        }

        private void btnAddProperty_Click(object sender, EventArgs e)
        {
            #region load xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlModelDesignUcDir);
            #endregion

            #region Determine where to add
            XmlElement root = xmlDocument.DocumentElement;
            XmlElement parent = root;
            if (txtDesType.Text != String.Empty && txtDesName.Text != String.Empty)
            {
                parent = GetXmlChildren(parent, txtDesType.Text, txtDesName.Text);
            }

            //Check if destination exist
            if (parent == null)
            {
                MessageBox.Show("Can not find where to add");
                return;
            }
            #endregion


            bool isChildOfModelDesign = true;
            if (parent.Name.Contains("ModelDesign") == false)
            {
                isChildOfModelDesign = false;

                parent = GotoChildrenElement(parent);
                //can add check null of parent here but not necessary
                //cause if it isn't ModelDesign, it suppose to have <opc:Children>
            }
            else { }

            #region Create xml tag for object
            XmlElement propertyElement = xmlDocument.CreateElement("opc", "Property", "http://opcfoundation.org/UA/ModelDesign.xsd");
            propertyElement.SetAttribute("SymbolicName", txtSymbolicName.Text);
            propertyElement.SetAttribute("DataType", "ua:Double");

            XmlElement childrenElement = xmlDocument.CreateElement("opc", "Children", "http://opcfoundation.org/UA/ModelDesign.xsd");
            propertyElement.AppendChild(childrenElement);
            XmlElement referencesElement = xmlDocument.CreateElement("opc", "References", "http://opcfoundation.org/UA/ModelDesign.xsd");
            propertyElement.AppendChild(referencesElement);

            if (isChildOfModelDesign)
            {
                /*
                 Create Reference tag
                    <opc:Reference IsInverse="true">
                        <opc:ReferenceType>ua:Organizes</opc:ReferenceType>
                        <opc:TargetId>ua:ObjectsFolder</opc:TargetId>
                     </opc:Reference>
                 */
                XmlElement referenceElement = xmlDocument.CreateElement("opc", "Reference", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceElement.SetAttribute("IsInverse", "true");
                referencesElement.AppendChild(referenceElement);

                XmlElement referenceTypeElement = xmlDocument.CreateElement("opc", "ReferenceType", "http://opcfoundation.org/UA/ModelDesign.xsd");
                referenceTypeElement.InnerText = "ua:Organizes";
                referenceElement.AppendChild(referenceTypeElement);
                XmlElement targetIdElement = xmlDocument.CreateElement("opc", "TargetId", "http://opcfoundation.org/UA/ModelDesign.xsd");
                targetIdElement.InnerText = "ua:ObjectsFolder";
                referenceElement.AppendChild(targetIdElement);
            }
            #endregion

            parent.AppendChild(propertyElement);

            xmlDocument.Save(xmlModelDesignUcDir);
        }
       

        /// <summary>
        /// Find child element of a root with name of xml tag and symbolicName.
        /// If symbolicName is empty then return the first child.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="tag"></param>
        /// <param name="symbolicName"></param>
        public XmlElement GetXmlChildren(XmlElement root, string tag, string symbolicName)
        {
            if (root == null)
            {
                return null;
            }
            XmlNodeList childRootList = root.ChildNodes;
            foreach (XmlElement child in childRootList)
            {
                if (child.Name.Contains(tag))
                {
                    //symbolicName is empty -> return first child
                    if (symbolicName == String.Empty | symbolicName == null)
                    {
                        return child;
                    }

                    if (symbolicName == child.GetAttribute("SymbolicName")) 
                    {
                        return child;
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// Get <opc:Children> xml element
        /// </summary>
        /// <param name="xmlElement"></param>
        /// <returns></returns>
        public XmlElement GotoChildrenElement(XmlElement xmlElement) 
        {
            if (xmlElement == null)
            {
                return null;
            }
            return GetXmlChildren(xmlElement, "Children", String.Empty);
        }

        private void tvwModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode treeNode = tvwModel.SelectedNode;
            string path = treeNode.FullPath;
        }
    }
}
