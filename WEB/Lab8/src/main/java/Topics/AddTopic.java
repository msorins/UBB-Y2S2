package Topics;

import Auth.AuthManager;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(name = "AddTopicServlet")
public class AddTopic extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String name = req.getParameter("name");
        String category = req.getParameter("category");
        String mail = (String) req.getSession().getAttribute("mail");


        if(mail == null) {
            System.out.println(  "This must not happen (mail null) ");
            resp.sendRedirect("/index.jsp");
            return;
        }

        Integer id = AuthManager.getUserIdByMail( mail );

        if(id == 0) {
            System.out.println( "This must not happen (id is 0) ");
            resp.sendRedirect("/index.jsp");
            return;
        }

        // Add the new topic
        TopicsManager.addNewTopic(name, category, id);

        // Redirect to index
        resp.sendRedirect("/index.jsp");
    }

}
