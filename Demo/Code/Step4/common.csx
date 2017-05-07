public string getVersionFromNuspecFile(string filePath)
{
    var doc = new System.Xml.XmlDocument();
    doc.Load(filePath);
    var versionNode = doc.GetElementsByTagName(
        "version", "http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd"
        )[0];
    return versionNode.InnerText;
}
