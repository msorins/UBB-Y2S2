package Posts;

import Auth.AuthManager;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(name = "AddPostServlet")
public class AddPost extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String text = req.getParameter("text");

        String mail = (String) req.getSession().getAttribute("mail");
        if(mail == null) {
            System.out.println(  "This must not happen (mail null) ");
            resp.sendRedirect("/index.jsp");
            return;
        }

        Integer userId = AuthManager.getUserIdByMail( mail );
        if(userId == 0) {
            System.out.println( "This must not happen (id is 0) ");
            resp.sendRedirect("/index.jsp");
            return;
        }

        String topicIdString = req.getParameter("topicId");
        if(userId == 0) {
            System.out.println( "This must not happen (topic id String is null) ");
            resp.sendRedirect("/index.jsp");
            return;
        }

        Integer topicId = Integer.parseInt( topicIdString);

        // Create the post
        PostsManager.addNewPost(topicId, userId, text);

        // Redirect to index*/
        resp.sendRedirect("/components/topic/viewTopic.jsp?id=" + topicIdString);
    }

}
