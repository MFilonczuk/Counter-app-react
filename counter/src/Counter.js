import React, {useState, useEffect} from 'react'
import AddIcon from '@mui/icons-material/Add';
import IconButton from '@mui/material/IconButton';
import RemoveIcon from '@mui/icons-material/Remove';
import RestartAltIcon from '@mui/icons-material/RestartAlt';
import axios from 'axios';
import Constants from './Constans';

export default function Counter() {
    const [number, setNumber] = useState(0);
    const userId = 1;

    const apiGet = axios.create({
        baseURL: Constants.API_URL_GET_NUMBER
    })

    function getNumber() 
    {
        apiGet.get().then(res => {
            setNumber(res.data.countNumber)    
        })
    }

    useEffect(() => {    
        getNumber();
     },[]);


    function addButton(){
        setNumber(nextNumber => {
            return nextNumber + 1;
        })
         axios.post(Constants.API_URL_INCREMENT_NUMBER, {
            id: userId
          })
          .then(function (response) {
            console.log(response);
          })
    }

    function subtractButton(){
        setNumber(prevNumber => {
            return (prevNumber > 0 ? prevNumber - 1 : prevNumber);
        })

        axios.post(Constants.API_URL_DECREMENT_NUMBER, {
            id: userId
          })
          .then(function (response) {
            console.log(response);
          })
    }

    function resetButton()
    {
        setNumber(0)
        
        axios.post(Constants.API_URL_RESET_NUMBER, {
            id: userId
          })
          .then(function (response) {
            console.log(response);
          })
    }

  return (
    <div className="main">
        <h1 className="title">
            Counter App
        </h1>
        <div className="counter-content">
            <IconButton color="primary" style={{padding: "35px"}} onClick={addButton}>
                <AddIcon /> 
            </IconButton>
            <span>You have clicked {number} {number == 1 ? "time" : "times"}</span>
            <IconButton color="primary" style={{padding: "35px"}} onClick={subtractButton} >
                <RemoveIcon />
            </IconButton>
            <p>
                <IconButton color="primary" onClick={resetButton} >
                    <RestartAltIcon />
                </IconButton>
            </p>
        </div>
    </div>
  )
}
