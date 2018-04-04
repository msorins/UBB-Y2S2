<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <html>
    <head>
      <link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
      <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

    </head>
    <body>
      <div class="row" style="margin-top:10%">
          <div class="col-md-2"> </div>
          <div class="col-md-8">

            <table class="main-section table table-striped" border="1">
              <tr class="header-row thead-dark">
                <th>Title</th>
                <th>Interpret Name</th>
                <th>Year</th>
              </tr>
              <xsl:for-each select="entries/entry">
                <tr class="data-row">
                  <td class="type-data">
                    <xsl:value-of select="title"/>
                  </td>
                  <td class="name-data">
                    <xsl:choose>
                      <xsl:when test="year='1998'">
                        <p class="text-danger"><xsl:value-of select="name"/></p>
                      </xsl:when>

                      <xsl:otherwise>
                        <xsl:value-of select="name"/>
                      </xsl:otherwise>
                    </xsl:choose>
                  </td>
                  <td class="year-data">
                    <xsl:value-of select="year"/>
                  </td>
                </tr>
              </xsl:for-each>
            </table>

           </div>
          <div class="col-md-2"> </div>
      </div>

    </body>
  </html>
</xsl:template>
</xsl:stylesheet>
