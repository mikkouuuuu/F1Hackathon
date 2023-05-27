import React, { useState } from 'react';
import axios from 'axios';
import Tabs from './Tabs';
import Slider from './common/slider';

export const Head2Head = () => {
  const f1Drivers = [
    'Hamilton', 'Verstappen', 'Bottas', 'Leclerc', 'Perez', 'Norris', 'Piastri', 'Sainz', 'Gasly',
    'Alonso', 'Ocon', 'DeVries', 'Stroll', 'Tsunoda', 'Hulkenberg', 'Magnussen', 'Albon', 'Sargeant', 'Zhou', 'Russell'
  ];

  const [driver1, setDriver1] = useState('');
  const [driver2, setDriver2] = useState('');
  const [leftSliderValue, setLeftSliderValue] = useState(0);
  const [rightSliderValue, setRightSliderValue] = useState(0);

  const handleDriver1Change = (event) => {
    setDriver1(event.target.value);
  };

  const handleDriver2Change = (event) => {
    setDriver2(event.target.value);
  };

  const handleSliderChange = (event) => {
    const value = parseInt(event.target.value);
    setLeftSliderValue(value);
    setRightSliderValue(23 - value);
  };

  const handleSubmit = () => {
    const data = {
      predictionGroupId: 1,
      predictionValues: [
        {
          describingValue: driver1,
          predictionValue: String(leftSliderValue)
        },
        {
          describingValue: driver2,
          predictionValue: String(rightSliderValue)
        }
      ]
    };
  
    axios.post('https://localhost:7037/Prediction/AddNew', data)
      .then(response => {
        console.log(response.data);
      })
      .catch(error => {
        console.error(error);
      });
  };
  

  return (
    <div className="grid justify-center">
      <Tabs />
      <div className="flex flex-col items-center mt-4 h-96 rounded bg-white">
        <h1 className="text-3xl text-black py-5 font-bold mb-4">Head 2 Head</h1>
        <div className="bg-white p-4 rounded shadow-md grid grid-cols-2 gap-4">
          <div>
            <label className="block text-gray-700 text-sm font-bold mb-2">Driver 1</label>
            <select
              value={driver1}
              onChange={handleDriver1Change}
              className="appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="driver1"
            >
              <option value="">Select a driver</option>
              {f1Drivers.map((surname, index) => (
                <option key={index} value={surname}>{surname}</option>
              ))}
            </select>
          </div>
          <div>
            <label className="block text-gray-700 text-sm font-bold mb-2">Driver 2</label>
            <select
              value={driver2}
              onChange={handleDriver2Change}
              className="appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="driver2"
            >
              <option value="">Select a driver</option>
              {f1Drivers.map((surname, index) => (
                <option key={index} value={surname}>{surname}</option>
              ))}
            </select>
          </div>
        </div>
        <div className='w-full py-4'>
          <Slider
            value={leftSliderValue}
            onChange={handleSliderChange}
          />
        </div>
        <div>
          <div className='flex justify-center'>
            <button
              onClick={handleSubmit}
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
              type="button"
            >
              Submit
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Head2Head;
