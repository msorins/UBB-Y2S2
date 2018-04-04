<?php

class SqlConfig {
  private $db_host = "127.0.0.1";
  private $db_user = "root";
  private $db_pass = "";
  private $db_name = "UbbWebLab7";

  public $con;
  public $db;

  public function connect() {
    if(!$this->con) {
          $this->con =  new PDO("mysql:host=$this->db_host;dbname=$this->db_name", $this->db_user, $this->db_pass, array(PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION));
          // Check connection
          if ($this->con) {
              return true;
          } else {
              return false;
          }
      } else
      {
          return true;
      }
  }
}
 ?>
