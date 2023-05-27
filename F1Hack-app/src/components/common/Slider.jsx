import React, { useState } from 'react';

const Slider = () => {
  const [sliderValue, setSliderValue] = useState(0);
  const maxValue = 23;

  const calculateLeftValue = () => {
    return sliderValue;
  };

  const calculateRightValue = () => {
    return maxValue - sliderValue;
  };

  const handleSliderChange = (event) => {
    setSliderValue(parseInt(event.target.value));
  };

  return (
    <div>
      
      <div className="relative flex items-center w-full">
        <div className="w-1/2 text-right pr-2">
          <span className="text-sm text-gray-500">{calculateLeftValue()}</span>
        </div>
        <input
          id="default-range"
          type="range"
          value={sliderValue}
          onChange={handleSliderChange}
          className="w-full h-2 bg-gray-200 rounded-lg appearance-none cursor-pointer dark:bg-gray-700"
          min="0"
          max={maxValue}
        />
        <div className="w-1/2 text-left pl-2">
          <span className="text-sm text-gray-500">{calculateRightValue()}</span>
        </div>
      </div>
    </div>
  );
};

export default Slider;
