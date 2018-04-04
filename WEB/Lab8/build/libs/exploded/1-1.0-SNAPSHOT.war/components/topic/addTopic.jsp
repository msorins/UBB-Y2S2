<%--
  Created by IntelliJ IDEA.
  User: so
  Date: 04/04/2018
  Time: 16:09
  To change this template use File | Settings | File Templates.
--%>

<form style="margin-left:15px; margin-right:15px;" action="/AddTopicServlet" method="post">
    <div class="row">
            <div class="col-md-5">
                <input type="text" name="name" class="form-control"  placeholder="Topic Name">
            </div>

            <div class="col-md-5">
                <input type="text" name="category" class="form-control"  placeholder="Topic category">
            </div>

            <div class="col-md-2">
                <button style="width:100%" type="submit" class="btn btn-primary"> + </button>
            </div>
    </div>
</form>