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
            <th>订单号</th>
            <th>客户名</th>
            <th>商品名</th>
            <th>单价</th>
            <th>购买数量</th>
            <th>客户号码</th>
          </tr>
<xsl:for-each select="OrderDetails">
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