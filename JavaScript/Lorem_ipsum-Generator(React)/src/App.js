import React, { useState } from 'react';
import data from './data';


function App() {
  const [count, setCount] = useState(0);
  const [text, setText] = useState([]);

  const submitHandler = () => {  };

  return (
    <section className="section-center">
      <h3>Tired of boring lorem ipsum?</h3>
      <form className="lorem-form" onSubmit={submitHandler}></form>
    </section>
  )
}

export default App;
