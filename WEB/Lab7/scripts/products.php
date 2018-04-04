<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);
require_once('sqlConfig.php');

class Products {
    private $sqlConfig;
    private $elemsPerPage = 2;

    function __construct($config) {
      $this->sqlConfig = $config;

      if(!$this->sqlConfig->connect()) {
        echo("ERROR CONNECTIN SQL");
      }

    }

    function select($category, $page) {
        if($category == "")
            $query = "SELECT * FROM Products";
        else
            $query = "SELECT * FROM Products WHERE productCategory = '$category'";

        $results = $this->getConnection()->query($query)->fetchAll(PDO::FETCH_ASSOC);
        return $this->filterByPage($results, $page);
    }

    function filterByPage($data, $page) {
        $filtered = [];
        $lowerBound = ($page - 1) * $this->elemsPerPage;
        $upperBound = $page * $this->elemsPerPage;

        for($i = $lowerBound;  $i < min(sizeof($data), $upperBound); $i += 1) {
            array_push( $filtered, $data[$i] );
        }

        return $filtered;
    }

    function insert($name, $category, $description, $price) {
        $query = $this->getConnection()->prepare("INSERT INTO Products (productName, productCategory, productDescription, productPrice) VALUES (?, ?, ?, ?)");
        $query->execute([$name, $category, $description, $price]);
    }


    function getConnection() {
        return $this->sqlConfig->con;
    }
}


$sqlConfigObj = new SqlConfig();
$productsObj = new Products($sqlConfigObj);

if( isset($_GET["action"]) )  {
    $action = $_GET["action"];

    if( $action == "insert" ) {

        if( isset($_POST["name"]) && isset($_POST["category"]) && isset($_POST["description"]) && isset($_POST["price"]) ) {
            $productsObj->insert( $_POST["name"], $_POST["category"], $_POST["description"], $_POST["price"] );
        } else {
            echo "Not all parameters supplied";
        }
    }

    if( $action == "select" ) {

        if( isset($_GET["page"]) ) {
            if( isset($_GET["category"]) ) {
                echo json_encode( $productsObj->select( $_GET["category"], $_GET["page"] ) );
            } else {
                echo json_encode( $productsObj->select( "", $_GET["page"]) );
            }
        } else {
            echo "Not all parameters supplied";
        }


    }
}

?>
