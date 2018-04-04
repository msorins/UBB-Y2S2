package Posts;

import DB.DBManager;
import Models.Post;
import Models.Topic;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class PostsManager {

    public static void addNewPost(Integer topicId, Integer byUserId, String text) {

        try {
            String sql = "INSERT INTO Posts(postTopicId, postByUserId, postText) VALUES ('"+ topicId.toString() + "', '"+ byUserId.toString() + "', '" + text + "');";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            stmt.execute();

        } catch(SQLException e) {
            e.printStackTrace();
        }

    }

    public static ArrayList<Post> getPostsByTopicId(Integer topicId) {
        ArrayList<Post> posts = new ArrayList<Post>();

        try {
            String sql = "SELECT * FROM Posts WHERE postTopicId = " + topicId.toString() + ";";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            ResultSet results = stmt.executeQuery();

            while(results.next()) {

                posts.add( new Post(
                        results.getInt(1),
                        results.getInt(2),
                        results.getInt(3),
                        results.getString(4)
                ));

            }

        } catch(SQLException e) {
            e.printStackTrace();
        }

        return posts;
    }

    public static void removePostById(Integer postId) {
        try {
            String sql = "DELETE FROM Posts WHERE id = " + postId.toString() + ";";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            stmt.execute();

        } catch(SQLException e) {
            e.printStackTrace();
        }
    }

}
