using System;
using System.Data.SqlTypes;
using System.IO;
using System.Text;
using System.Xml;

namespace test_XmlDesigner
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* --------------------------------- */
            //string path = "D:\\Proj\\VStudio\\test_XmlDesigner\\ModelDesign.xml";

            //// Load the XML document
            //XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(path); // xmlString is the XML string you provided

            //// Set up the namespace manager with the required namespaces
            //XmlNamespaceManager nsMgr = new XmlNamespaceManager(xmlDoc.NameTable);
            //nsMgr.AddNamespace("opc", "http://opcfoundation.org/UA/ModelDesign.xsd");

            //// Construct the XPath expression
            ////string xpath = "//opc:Object[@SymbolicName='hello']";
            //string xpath = $"//opc:Object[@SymbolicName='hello']";

            //// Select the desired element
            //XmlNode helloNode = xmlDoc.SelectSingleNode(xpath, nsMgr);
            //XmlElement helloElement = helloNode as XmlElement;
            /* --------------------------------- */


            //#region get uanodes file
            //string resourcePath = String.Empty;
            //string modelCompilerOutputsDir = @"D:\Proj\VStudio\MyOPCUAServer\InformationModelling\ModelCompilerOutputs";
            //string[] files = Directory.GetFiles(modelCompilerOutputsDir);
            //foreach (string file in files)
            //{
            //    if (Path.GetExtension(file) == ".uanodes")
            //    {
            //        resourcePath = file;
            //        break;
            //    }
            //}

            //string temp = resourcePath;
            //#endregion

            /* --------------------------------- */
            string path = @"D:\Proj\VStudio\Test_OpcUaDesigner\test_XmlDesigner\ModelDesign.xml";

            #region Model Design XML initially set up
            // Create the XML document
            XmlDocument xmlDoc = new XmlDocument();

            // Create the <?xml version="1.0" encoding="utf-8" ?> declaration
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(xmlDeclaration);
            // Create the <opc:ModelDesign> element (root element)
            XmlElement modelDesignElement = xmlDoc.CreateElement("opc", "ModelDesign", "http://opcfoundation.org/UA/ModelDesign.xsd");
            //XmlElement modelDesignElement = xmlDoc.CreateElement("opc", "ModelDesign", null);
            xmlDoc.AppendChild(modelDesignElement);

            // Add the xmlns attributes to the <opc:ModelDesign> element
            modelDesignElement.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            modelDesignElement.SetAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            modelDesignElement.SetAttribute("xmlns:opc", "http://opcfoundation.org/UA/ModelDesign.xsd");
            modelDesignElement.SetAttribute("xmlns:ua", "http://opcfoundation.org/UA/");
            modelDesignElement.SetAttribute("xmlns:uax", "http://opcfoundation.org/UA/2008/02/Types.xsd");
            modelDesignElement.SetAttribute("xmlns", "http://opcfoundation.org/OPCUAServer");
            modelDesignElement.SetAttribute("TargetNamespace", "http://opcfoundation.org/OPCUAServer");
            #endregion

            #region Create namespace
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

            modelDesignElement.InsertBefore(xmlDoc.CreateComment("\t\t\tCreate namespace\t\t\t"), namespacesElement);

            #endregion

            #region Create an information model standard based on OPC UA
            //xmlDoc.InsertBefore(xmlDoc.CreateComment("\t\t\tCreate an information model standard based on OPC UA\t\t\t"), modelDesignElement);

            #region Defining Types
            //xmlDoc.InsertBefore(xmlDoc.CreateComment("Defining Types"), modelDesignElement);

            #region Object and Variables Types
            //xmlDoc.InsertBefore(xmlDoc.CreateComment("Object and Variables Types"), modelDesignElement);


            // Create the <opc:ObjectType> element
            XmlElement objectTypeElement = xmlDoc.CreateElement("opc", "ObjectType", "http://opcfoundation.org/UA/ModelDesign");
            /*--- The xmlns:opc MUST NOT be place at the end of all the attributes of ObjectTypes
             * That create fault during model compiler operation --- */
            objectTypeElement.SetAttribute("xmlns:opc", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectTypeElement.SetAttribute("SymbolicName", "GenericSensorType");
            objectTypeElement.SetAttribute("BaseType", "ua:BaseObjectType");
            modelDesignElement.AppendChild(objectTypeElement);

            // Create the <opc:Description> element and add it to the <opc:ObjectType> element
            XmlElement descriptionElement = xmlDoc.CreateElement("opc", "Description", "http://opcfoundation.org/UA/ModelDesign");
            descriptionElement.InnerText = "A generic sensor.";
            objectTypeElement.AppendChild(descriptionElement);

            // Create the <opc:Children> element and add it to the <opc:ObjectType> element
            XmlElement childrenElement = xmlDoc.CreateElement("opc", "Children", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectTypeElement.AppendChild(childrenElement);

            // Create the <opc:Variable> element and add it to the <opc:Children> element
            XmlElement variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "Value");
            variableElement.SetAttribute("DataType", "ua:Double");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("TypeDefinition", "ua:AnalogItemType");
            variableElement.SetAttribute("AccessLevel", "Read");
            childrenElement.AppendChild(variableElement);

            #region Create MotorType
            /* ---------------- Create MotorType ---------------- */

            // Create the <opc:ObjectType> element
            objectTypeElement = xmlDoc.CreateElement("opc", "ObjectType", "http://opcfoundation.org/UA/ModelDesign");
            /*--- The xmlns:opc MUST NOT be place at the end of all the attributes of ObjectTypes
             * That create fault during model compiler operation --- */
            objectTypeElement.SetAttribute("xmlns:opc", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectTypeElement.SetAttribute("SymbolicName", "MotorType");
            objectTypeElement.SetAttribute("BaseType", "ua:BaseObjectType");
            modelDesignElement.AppendChild(objectTypeElement);

            // Create the <opc:Description> element and add it to the <opc:ObjectType> element
            descriptionElement = xmlDoc.CreateElement("opc", "Description", "http://opcfoundation.org/UA/ModelDesign");
            descriptionElement.InnerText = "Motor DataType.";
            objectTypeElement.AppendChild(descriptionElement);

            // Create the <opc:Children> element and add it to the <opc:ObjectType> element
            childrenElement = xmlDoc.CreateElement("opc", "Children", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectTypeElement.AppendChild(childrenElement);

            // Create the <opc:Variable> element and add it to the <opc:Children> element
            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "Mode");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "Start");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "Stop");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "StartCondition");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "StopCondition");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "RunFeedback");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "CMD");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            variableElement = xmlDoc.CreateElement("opc", "Variable", "http://opcfoundation.org/UA/ModelDesign.xsd");
            variableElement.SetAttribute("SymbolicName", "Fault");
            variableElement.SetAttribute("DataType", "ua:Boolean");
            variableElement.SetAttribute("ValueRank", "Scalar");
            variableElement.SetAttribute("AccessLevel", "ReadWrite");
            childrenElement.AppendChild(variableElement);

            #endregion

            #region Create TankBatchSystemType

            objectTypeElement = xmlDoc.CreateElement("opc", "ObjectType", "http://opcfoundation.org/UA/ModelDesign");
            /*--- The xmlns:opc MUST NOT be place at the end of all the attributes of ObjectTypes
             * That create fault during model compiler operation --- */
            objectTypeElement.SetAttribute("xmlns:opc", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectTypeElement.SetAttribute("SymbolicName", "TankBatchSystemType");
            objectTypeElement.SetAttribute("BaseType", "ua:BaseObjectType");
            objectTypeElement.SetAttribute("SupportsEvents", "true");
            modelDesignElement.AppendChild(objectTypeElement);

            descriptionElement = xmlDoc.CreateElement("opc", "Description", "http://opcfoundation.org/UA/ModelDesign");
            descriptionElement.InnerText = "A production batch plant.";
            objectTypeElement.AppendChild(descriptionElement);

            childrenElement = xmlDoc.CreateElement("opc", "Children", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectTypeElement.AppendChild(childrenElement);

            XmlElement objectElement = xmlDoc.CreateElement("opc", "Object", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.SetAttribute("SymbolicName", "Motor1");
            objectElement.SetAttribute("TypeDefinition", "MotorType");
            objectElement.SetAttribute("SupportsEvents", "true");
            childrenElement.AppendChild(objectElement);
            XmlElement browseNameElement = xmlDoc.CreateElement("opc", "BrowseName", "http://opcfoundation.org/UA/ModelDesign.xsd");
            browseNameElement.InnerText = "Motor1";
            objectElement.AppendChild(browseNameElement);

            objectElement = xmlDoc.CreateElement("opc", "Object", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.SetAttribute("SymbolicName", "Motor2");
            objectElement.SetAttribute("TypeDefinition", "MotorType");
            objectElement.SetAttribute("SupportsEvents", "true");
            childrenElement.AppendChild(objectElement);
            browseNameElement = xmlDoc.CreateElement("opc", "BrowseName", "http://opcfoundation.org/UA/ModelDesign.xsd");
            browseNameElement.InnerText = "Motor2";
            objectElement.AppendChild(browseNameElement);


            objectElement = xmlDoc.CreateElement("opc", "Object", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.SetAttribute("SymbolicName", "Motor3");
            objectElement.SetAttribute("TypeDefinition", "MotorType");
            objectElement.SetAttribute("SupportsEvents", "true");
            childrenElement.AppendChild(objectElement);
            browseNameElement = xmlDoc.CreateElement("opc", "BrowseName", "http://opcfoundation.org/UA/ModelDesign.xsd");
            browseNameElement.InnerText = "Motor3";
            objectElement.AppendChild(browseNameElement);


            #endregion

            #region Create Motor

            objectElement = xmlDoc.CreateElement("opc", "Object", "http://opcfoundation.org/UA/ModelDesign");
            /*--- The xmlns:opc MUST NOT be place at the end of all the attributes of ObjectTypes
             * That create fault during model compiler operation --- */
            objectElement.SetAttribute("xmlns:opc", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.SetAttribute("SymbolicName", "TankBatch");
            objectElement.SetAttribute("TypeDefinition", "TankBatchSystemType");
            objectElement.SetAttribute("SupportsEvents", "true");
            modelDesignElement.AppendChild(objectElement);

            browseNameElement = xmlDoc.CreateElement("opc", "BrowseName", "http://opcfoundation.org/UA/ModelDesign.xsd");
            browseNameElement.InnerText = "System";
            objectElement.AppendChild(browseNameElement);

            XmlElement referencesElement = xmlDoc.CreateElement("opc", "References", "http://opcfoundation.org/UA/ModelDesign.xsd");
            objectElement.AppendChild(referencesElement);

            XmlElement referenceElement = xmlDoc.CreateElement("opc", "Reference", "http://opcfoundation.org/UA/ModelDesign.xsd");
            referenceElement.SetAttribute("IsInverse", "true");
            referencesElement.AppendChild(referenceElement);

            XmlElement referenceTypeElement = xmlDoc.CreateElement("opc", "ReferenceType", "http://opcfoundation.org/UA/ModelDesign.xsd");
            referenceTypeElement.InnerText = "ua:Organizes";
            referenceElement.AppendChild(referenceTypeElement);
            XmlElement targetIdElement = xmlDoc.CreateElement("opc", "TargetId", "http://opcfoundation.org/UA/ModelDesign.xsd");
            targetIdElement.InnerText = "ua:ObjectsFolder";
            referenceElement.AppendChild(targetIdElement);

            #endregion

            #endregion

            #region Reference Types
            #endregion

            #region DataTypes
            #endregion


            #endregion

            #region Defining Standard Method

            #endregion

            #region Defining Properties

            #endregion

            #region Defining Modeling Rules

            #endregion

            #region Defining Encoding Data Types

            #endregion

            #endregion


            xmlDoc.Save(path);
            /* --------------------------------- */


        }

    }
}   