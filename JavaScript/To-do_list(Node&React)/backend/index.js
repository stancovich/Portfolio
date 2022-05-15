const express = require('express');
const mongoose = require("mongoose");
const cors = require("cors");
const app = express();

const todoRoutes = require("./routes/todoRoutes");

app.use(express.json());
app.use(cors());

mongoose.connect("mongodb://localhost/todolist") 
.then(() => { console.log("Connected successfully") })
.catch((err) => {console.error(err)})

app.use("/todos", todoRoutes);

const PORT = 3030;

app.listen(PORT, () => {
    console.log("The server is listening on port " + PORT);
})