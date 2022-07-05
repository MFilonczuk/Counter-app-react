import React, {useState, useEffect} from 'react'

export default function Footer() {
    
    const[counter, setCounter] = useState(0);

    useEffect(() => {
      const seconds = setInterval(() => {
        setCounter(counter + 1);
      }, 1000);
  
      return () => {
        clearInterval(seconds);
      };
    }, [counter]);

    const parseTime = (currentSecond) => {
      var m = Math.floor(currentSecond % 3600 / 60);
      var s = Math.floor(currentSecond % 3600 % 60);

      var mDisplay = m > 0 ? m + (m == 1 ? " minute and " : " minutes and ") : "";
      var sDisplay = s > 0 ? s + (s == 1 ? " second" : " seconds") : "";
      return mDisplay + sDisplay; 
    }

    const todayDate = () => {
      var today = new Date();
      var date = ("0" + today.getDate()).slice(-2) + "." + ("0" + (today.getMonth() + 1)).slice(-2) + "." + today.getFullYear() + " " 
      + ("0" + today.getHours()).slice(-2) + ":" + ("0" + today.getMinutes()).slice(-2) ;
      return date
    }

  return (
    <footer>
        You have spent  {parseTime(counter)} on website
        <p>Today is: {todayDate()}</p>
        <p> &copy; FMichał</p>
    </footer>
  )
}
