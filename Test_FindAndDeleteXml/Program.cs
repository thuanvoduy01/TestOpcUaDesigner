using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Test_FindAndDeleteXml
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\Proj\VStudio\Test_OpcUaDesigner\Test_FindAndDeleteXml\ModelDesignFindAndDel.xml";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("opc", "http://opcfoundation.org/UA/ModelDesign.xsd");

            XmlElement root = xmlDoc.DocumentElement;
            string temp = GetNodeSymbolicNamePath(root);

            XmlNode helloObject = xmlDoc.SelectSingleNode("//opc:Object[@SymbolicName='obj11']", nsmgr);
            temp = GetNodeSymbolicNamePath(helloObject);
            //if (helloObject != null)
            //{
            //    helloObject.ParentNode.RemoveChild(helloObject);
            //}


            XmlNode xmlDeleteNode = null;
            XmlNodeList nodeList = xmlDoc.SelectNodes("//opc:Object[@SymbolicName='obj1']", nsmgr);

            temp = GetNodeSymbolicNamePath(nodeList[1]);


            if (nodeList.Count > 0 ) 
            {
                string pathTreeview = @"ModelDesign\UIObject2\obj1";
                foreach (XmlNode node in nodeList)
                {
                    string nodePath = GetNodeSymbolicNamePath(node);
                    if (nodePath == pathTreeview)
                    {
                        xmlDeleteNode = node;
                        break;
                    }

                }
            }

            if (xmlDeleteNode != null)
            {
                xmlDeleteNode.ParentNode.RemoveChild(xmlDeleteNode);
            }

            xmlDoc.Save(path);

            
            
        }

        /// <summary>
        /// Return something like "ModelDesign\\{symbolic1}\\{symbolic2}
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        static string GetNodeSymbolicNamePath(XmlNode node)
        {
            if (node == null)
            {
                return String.Empty;
            }

            if (node.Name.Contains("ModelDesign"))
            {
                return $"ModelDesign";
            }

            if (node.Name.Contains("Children"))
            {
                return GetNodeSymbolicNamePath(node.ParentNode);
            }
            
            return $"{GetNodeSymbolicNamePath(node.ParentNode)}\\{node.Attributes["SymbolicName"].Value}";

            #region this works
            //if (node == null)
            //{
            //    return String.Empty;
            //}

            //if (node.Name.Contains("ModelDesign"))
            //{
            //    return $"ModelDesign";
            //}

            //XmlNode nodeParent = node.ParentNode;

            //if (nodeParent.Name.Contains("ModelDesign"))
            //{
            //    return $"ModelDesign\\{node.Attributes["SymbolicName"].Value}";
            //}

            //if (nodeParent.Name.Contains("Children"))
            //{
            //    nodeParent = nodeParent.ParentNode;
            //}

            //string tempStr = GetNodeSymbolicNamePath(nodeParent);
            //tempStr = tempStr + "\\" + node.Attributes["SymbolicName"].Value;
            //return tempStr;
            ////return $"{GetNodeSymbolicNamePath(nodeParent)}\\{node.Attributes["SymbolicName"].Value}";
            #endregion
        }
    }
}
