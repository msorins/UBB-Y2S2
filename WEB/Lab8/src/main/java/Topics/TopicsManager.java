package Topics;

import DB.DBManager;
import Models.Topic;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class TopicsManager {

    public static void addNewTopic(String name, String category, Integer byUserId) {

        try {
            String sql = "INSERT INTO Topics(topicName, topicCategory, topicByUserId) VALUES ('"+ name + "', '"+ category + "', '" + byUserId.toString() + "');";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            stmt.execute();

        } catch(SQLException e) {
            e.printStackTrace();
        }

    }

    public static ArrayList<Topic> getAllTopics() {
        ArrayList<Topic> topics = new ArrayList<Topic>();

        try {
            String sql = "SELECT * FROM Topics";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            ResultSet results = stmt.executeQuery();

            while(results.next()) {

                topics.add( new Topic( results.getInt(1),
                                       results.getString(2),
                                       results.getString(3),
                                       results.getInt(4) )
                );
            }


        } catch(SQLException e) {
            e.printStackTrace();
        }

        return topics;
    }
}
