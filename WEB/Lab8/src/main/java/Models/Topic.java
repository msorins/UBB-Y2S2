package Models;

public class Topic {
    private Integer id;
    private String topicName;
    private String topicCategory;
    private Integer topicByUserId;

    public Topic(Integer id, String topicName, String topicCategory, Integer topicByUserId) {
        this.id = id;
        this.topicName = topicName;
        this.topicCategory = topicCategory;
        this.topicByUserId = topicByUserId;
    }

    public Topic() {
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getTopicName() {
        return topicName;
    }

    public void setTopicName(String topicName) {
        this.topicName = topicName;
    }

    public String getTopicCategory() {
        return topicCategory;
    }

    public void setTopicCategory(String topicCategory) {
        this.topicCategory = topicCategory;
    }

    public Integer getTopicByUserId() {
        return topicByUserId;
    }

    public void setTopicByUserId(Integer topicByUserId) {
        this.topicByUserId = topicByUserId;
    }
}
