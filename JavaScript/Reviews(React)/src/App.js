import React from 'react';
import Review from './Review';
import { FaGithubSquare } from 'react-icons/fa';
function App() {
  return (
    <main>
      <div className="container">
        <section className="title">
          <h2>Our reviews</h2>
          <div className="underline" />
          <Review />
        </section>
      </div>
    </main>
  );
}

export default App;
