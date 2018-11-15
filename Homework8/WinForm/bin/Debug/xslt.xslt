<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>
	
	<xsl:template match="ArrayOfOrderDetails">
	   <html>
      <head><title>Order List</title></head>
      <body>
        <table border="1">
          <tr  bgcolor="#fc9ce7">
            <th>������</th>
            <th>�ͻ���</th>
            <th>��Ʒ��</th>
            <th>����</th>
            <th>��������</th>
            <th>�ͻ�����</th>
          </tr>
<xsl:for-each select="Order">
            <tr>
              <td>
                <xsl:value-of select="orderNumber"/>
              </td>
              <td>
                <xsl:value-of select="Name"/>
              </td>
              <td>
                <xsl:value-of select="goodsName"/>
              </td>
              <td>
                <xsl:value-of select="Price"/>
              </td>
              <td>
                <xsl:value-of select="goodsNumber"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
            </tr>
          </xsl:for-each>
		 </table>
		
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>