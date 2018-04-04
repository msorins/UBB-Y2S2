<%--
  Created by IntelliJ IDEA.
  User: so
  Date: 04/04/2018
  Time: 16:15
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Auth</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>
    <%@ include file="/components/pageElems/navbar.jsp" %>

    <%
        if(request.getParameter("error") != null) {
    %>
        <div class="alert alert-warning">
            <strong>Warning!</strong> <%= request.getParameter("error")  %>
         </div>
    <%
        }
    %>
    <div class="container">
        <div class="row">

            <div style="border-right: 1px black;" class="col-md-6">
                <a href="login.jsp"> <p style="text-align:center"><img class="authIcon" src="/imgs/login.svg"></p> </a>
            </div>

            <div class="col-md-6">
                <a href="register.jsp"> <p style="text-align:center"><img class="authIcon" src="/imgs/register.svg"></p> </a>
            </div>
        </div>
    </div>
</body>

<style>
    .authIcon {
        height: 70%;
        width: 50%;
    }
</style>
</html>
