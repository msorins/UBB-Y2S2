package Posts;

import Auth.AuthManager;
import Models.Post;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

@WebServlet(name = "RemovePostServlet")
public class RemovePost extends HttpServlet {

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String postIdString = req.getParameter("postId");
        String topicIdString = req.getParameter("topicId");

        if(postIdString == null || topicIdString == null) {
            System.out.println(  "This must not happen (postId null or topicId null) ");
            resp.sendRedirect("/index.jsp");
            return;
        }

        int postId  = Integer.parseInt( postIdString );

        // Remove the post with that given id
        PostsManager.removePostById(postId);

        // Redirect to index*/
        resp.sendRedirect("/components/topic/viewTopic.jsp?id=" + topicIdString);
    }

}
