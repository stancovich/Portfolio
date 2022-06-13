import React, { useState, useEffect } from 'react'
import Loading from './Loading'
import Tours from './Tours'
// ATTENTION!!!!!!!!!!
// I SWITCHED TO PERMANENT DOMAIN
const url = 'https://course-api.com/react-tours-project'
function App() {
  const [loading, setLoading] = useState(true);
  const [tours, setTours] = useState([]);

  const removeTourHandler = (id) => {
    const newTours = tours.filter((tour) => tour.id !== id);
    setTours(newTours);
  };
  const refreshButtonClickHandler = () => {
    fetchTours();
  };
  const fetchTours = async () => {
    setLoading(true);
    fetch(url)
      .then((response) => {
        if (response.status >= 200 && response.status < 300) {
          console.log(response)
          return response.json();
        } else {
          setLoading(false);
          throw new Error(response.status + ': ' + response.status);
        }
      })
      .then((tours) => {
        setLoading(false);
        setTours(tours);
        console.log(tours);
      })
  }

  useEffect(() => {
    fetchTours();
  }, []);

  if (loading) {
    return (
      <main>
        <Loading />
      </main>
    )
  };
  if (tours.length === 0) {
    return (
      <div className="title">
        <h2>No tours left!</h2>
        <button onClick={refreshButtonClickHandler} className="btn">Refresh</button>
      </div>
    )
  }
  return (
    <main>
      <Tours tours={tours} removeTour={removeTourHandler} />
    </main>
  )
}

export default App
