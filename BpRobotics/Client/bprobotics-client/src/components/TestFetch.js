import React from 'react'
import useFetch from '../useFetch'

const TestFetch = () => {
  const { data, loading, error, getFetch, postFetch } = useFetch();
  const body = {
    "name": "TestPotion",
    "ingredients": [
        {
            "name": "Bauxit"
        },
        {
            "name": "Főzelék"
        }
    ],
    "status": 0,
    "recipe": {
        "name": "Bauxit főzelék",
        "brewer": null,
        "ingredients": null
    }
}

  if (loading) return <h1>Loading</h1>;

  if (error) console.log(error);

  return (
    <>
      <div>{ data }</div>
      <button onClick={()=>{postFetch("/1", body)}}>Postfectch</button>
    </>
  )
}

export default TestFetch