const express = require("express");
const app = express();

const mysql = require("mysql")

const connection = mysql.createPool({
    host: "127.0.0.1",
    user: "root",
    password: "",
    database: "sikkerhed",
    multipleStatements: true
})

app.use(express.urlencoded({extended:true}))

app.post("/id", (req, res)=>{
    const name = req.body.id;

    connection.query(`SELECT id FROM employees WHERE id = ?`, [name], (err,result) => {
        res.append('Access-Control-Allow-Origin', '*');
        res.append('content-type', 'text/plain');
        if(err) res.send(err.sqlMessage)
        else res.send(result);
    })
})

app.post("/", (req, res)=>{
    connection.query(`SELECT * FROM employees`, (err,result) => {
        res.append('Access-Control-Allow-Origin', '*');
        res.append('content-type', 'text/plain');
        if(err) res.send(err.sqlMessage)
        else res.send(result);
    })
})

app.listen(8080)