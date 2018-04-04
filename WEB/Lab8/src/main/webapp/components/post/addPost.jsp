<%--
  Created by IntelliJ IDEA.
  User: so
  Date: 04/04/2018
  Time: 18:03
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<form action="/AddPostServlet?topicId=<%= request.getParameter("id")%>" method="post">
    <div style="background-color: #f2f2f2 " class="row">
         <textarea style="width:100%" name="text"></textarea>
         <button style="width:100%"  type="submit" class="btn btn-primary"> + </button>
    </div>
</form>

</html>
