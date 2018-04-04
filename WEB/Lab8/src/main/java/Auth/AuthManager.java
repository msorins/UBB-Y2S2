package Auth;

import DB.DBManager;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class AuthManager {
    public static int getUserIdByMail(String mail) {
        try {
            String sql = "SELECT * FROM Users where userEmail = '" + mail +"';";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            ResultSet results = stmt.executeQuery();

            while(results.next()) {
                return results.getInt(1);
            }
            return 0;

        } catch(SQLException e) {
            e.printStackTrace();
        }

        return 0;
    }

    public static String getUserNameById(Integer id) {
        try {
            String sql = "SELECT * FROM Users where id = " + id +";";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            ResultSet results = stmt.executeQuery();

            while(results.next()) {
                return results.getString(3);
            }
            return "";

        } catch(SQLException e) {
            e.printStackTrace();
        }

        return "";
    }

    public static Boolean validUserLogin(String mail, String encryptedPassword) {
        try {
            String sql = "SELECT * FROM Users where userEmail = '" + mail +"' AND userPassword = '" + encryptedPassword + "';";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            ResultSet results = stmt.executeQuery();

            while(results.next()) {
                return true;
            }
            return false;

        } catch(SQLException e) {
            e.printStackTrace();
        }

        return false;
    }

    public static void addUserToDataBase(String mail, String name, String encryptedPassword) {
        String sql = "INSERT INTO Users(userEmail, userName, userPassword) VALUES ('" + mail + "','" + name + "','" + encryptedPassword + "');";
        System.out.println( sql );
        // Execute the query
        try {
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            stmt.execute();
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static Boolean isMailUnique(String mail) {
        try {
            String sql = "SELECT * FROM Users where userEmail = '" + mail +"';";
            PreparedStatement stmt = DBManager.getConnection().prepareStatement(sql);
            ResultSet results = stmt.executeQuery();

            while(results.next()) {
                return false;
            }
            return true;

        } catch(SQLException e) {
            e.printStackTrace();
        }

        return false;
    }

    public static String encrypt(String passwordToHash) {
        String generatedPassword = null;
        try {
            // Create MessageDigest instance for MD5
            MessageDigest md = MessageDigest.getInstance("MD5");
            //Add password bytes to digest
            md.update(passwordToHash.getBytes());
            //Get the hash's bytes
            byte[] bytes = md.digest();
            //This bytes[] has bytes in decimal format;
            //Convert it to hexadecimal format
            StringBuilder sb = new StringBuilder();
            for(int i=0; i< bytes.length ;i++)
            {
                sb.append(Integer.toString((bytes[i] & 0xff) + 0x100, 16).substring(1));
            }
            //Get complete hashed password in hex format
            generatedPassword = sb.toString();
        }
        catch (NoSuchAlgorithmException e)
        {
            e.printStackTrace();
        }
        return generatedPassword;
    }
}

