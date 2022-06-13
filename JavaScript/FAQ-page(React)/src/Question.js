import React, { useState } from 'react';
import { AiOutlineMinus, AiOutlinePlus } from 'react-icons/ai';
const Question = ({ questionsData, title, info }) => {
  const [showInfo, setShowInfo] = useState(false)
  const showHideInfoHandler = () => {
    setShowInfo(!showInfo);
  };
  const faqInfo = (<div> {info} </div>);
  return (
    <article className="question">
      <header>
        <h4 onClick={showHideInfoHandler}> {title} </h4>
        <button className="btn" onClick={showHideInfoHandler}>{showInfo ? <AiOutlineMinus /> : <AiOutlinePlus />}</button>
      </header>
      {showInfo && faqInfo}
    </article>
  );
};

export default Question;
