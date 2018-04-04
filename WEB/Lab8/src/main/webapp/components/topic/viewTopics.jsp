<%@ page import="Topics.AddTopic" %>
<%@ page import="Topics.TopicsManager" %>
<%@ page import="Models.Topic" %><%--
  Created by IntelliJ IDEA.
  User: so
  Date: 04/04/2018
  Time: 16:10
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>

<%  for(Topic topic :TopicsManager.getAllTopics()) { %>
    <div class="container">
        <div class="card-columns">
            <div class="card">
                <div class="card-body">
                    <a href="/components/topic/viewTopic.jsp?id=<%=topic.getId()%>"> <h5 class="card-title"><%= topic.getTopicName() %></h5> </a>
                    <p class="card-text"><small class="text-muted"> <%= topic.getTopicCategory() %> </small></p>
                </div>
            </div>
        </div>
    </div>

<% } %>

</html>
