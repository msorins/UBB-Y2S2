package Models;

public class Post {
    private Integer id;
    private Integer postTopicId;
    private Integer postByUserId;
    private String postText;

    public Post(Integer id, Integer postTopicId, Integer postByUserId, String postText) {
        this.id = id;
        this.postTopicId = postTopicId;
        this.postByUserId = postByUserId;
        this.postText = postText;
    }

    public Post() {
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getPostTopicId() {
        return postTopicId;
    }

    public void setPostTopicId(Integer postTopicId) {
        this.postTopicId = postTopicId;
    }

    public Integer getPostByUserId() {
        return postByUserId;
    }

    public void setPostByUserId(Integer postByUserId) {
        this.postByUserId = postByUserId;
    }

    public String getPostText() {
        return postText;
    }

    public void setPostText(String postText) {
        this.postText = postText;
    }
}
