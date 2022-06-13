import React, { useState, useEffect } from 'react'
import { FaAngleDoubleRight } from 'react-icons/fa'
// ATTENTION!!!!!!!!!!
// I SWITCHED TO PERMANENT DOMAIN
const url = 'https://course-api.com/react-tabs-project'
function App() {
  const [loading, setLoading] = useState(true);
  const [jobs, setJobs] = useState([]);
  const [tab, setTab] = useState(0);


  const fetchJobs = async () => {
    // fetch(url)
    //   .then((response) => {
    //     if (response.status >= 200 && response.status < 300) {
    //       return response.json();
    //     } else {
    //       setLoading(false);
    //       throw new Error('Status: ' + response.status);
    //     }
    //   })
    //   .then((jobs) => {
    //     setLoading(false);
    //     setJobs(jobs);
    //   })
    const response = await fetch(url);
    const newJobs = await response.json();
    setJobs(newJobs);
    setLoading(false);
  }
  useEffect(() => {
    fetchJobs();
  }, [])

  if (loading) {
    return (
      <section className="section loading">
        <h1>Loading..</h1>
      </section>
    )
  }
  console.log(jobs);

  const { company, dates, duties, title } = jobs[tab];
  return (
    <section className="section">
      <div className="title">
        <h2>Experience</h2>
        <div className="underline"></div>
      </div>
      <div className="jobs-center">
        {/* Button container */}
        <div className="btn-container">
          {jobs.map((job, index) => {
            return (
              <button key={job.id} className={`job-btn ${index === tab && 'active-btn'}`} onClick={() => { setTab(index) }}> {job.company}</button>
            )
          })}
        </div>
        {/* Job information */}
        <article className="job-info">
          <h3>{title}</h3>
          <h4>{company}</h4>
          <p className="job-date">{dates}</p>
          {duties.map((duty, i) => {
            return (
              <div key={i} className="job-desc">
                <FaAngleDoubleRight className="job-icon" />
                <p>{duty}</p>
              </div>
            )
          })}
        </article>
      </div>
    </section>
  )
}

export default App
