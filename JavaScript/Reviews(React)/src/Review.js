import React, { useState } from 'react';
import people from './data';
import { FaChevronLeft, FaChevronRight, FaQuoteRight } from 'react-icons/fa';

const Review = () => {
  const [index, setIndex] = useState(0);
  const { name, job, image, text } = people[index];

  const preventIndexOutOfLimit = (index) => {
    if (index > people.length - 1) {
      return people.length - 1;
    }
    if (index < 0) {
      return 0;
    }
    return index;
  };
  const increaseIndexClickHandler = () => {
    setIndex((oldIndex) => {
      const newIndex = oldIndex + 1;
      return preventIndexOutOfLimit(newIndex);
    })
  };
  const decreaseIndexClickHandler = () => {
    setIndex((oldIndex) => {
      const newIndex = oldIndex - 1;
      return preventIndexOutOfLimit(newIndex);
    })
  };
  const randomReviewClickHandler = () => {
    let randomNumber = Math.floor(Math.random() * people.length);
    if (randomNumber === index) {
      randomNumber = index + 1;
    }
    setIndex(preventIndexOutOfLimit(randomNumber));
  };

  return (
    <article className="review">
      <div className="img-container">
        <img src={image} alt={name} className="person-img" />
        <span className="quote-icon">
          <FaQuoteRight />
        </span>
      </div>
      <h4 className="author">
        {name}
      </h4>
      <p className="job">
        {job}
      </p>
      <p className="info">
        {text}
      </p>
      <div className="button-container">
        {index > 0 && <button className="prev-btn" onClick={decreaseIndexClickHandler}><FaChevronLeft /></button>}
        {index < people.length - 1 && <button className="next-btn" onClick={increaseIndexClickHandler}><FaChevronRight /></button>}
      </div>
      <button className="random-btn" onClick={randomReviewClickHandler}>Surprise me!</button>
    </article >
  );
};

export default Review;
