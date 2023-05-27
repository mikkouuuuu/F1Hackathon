import React from 'react';

const Head2Head = () => {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen">
      <h1 className="text-3xl font-bold mb-4">Head2Head</h1>
      
      <div className="flex flex-col space-y-4">
        <label htmlFor="driver1">driver 1:</label>
        <select
          id="driver1"
          className="px-4 py-2 border rounded-md"
          defaultValue="" // Placeholder value
        >
          <option value="" disabled></option>
          <option value="option1">Option 1</option>
          <option value="option2">Option 2</option>
          <option value="option3">Option 3</option>
        </select>

        <label htmlFor="driver2">driver 2:</label>
        <select
          id="driver2"
          className="px-4 py-2 border rounded-md"
          defaultValue="" // Placeholder value
        >
          <option value="" disabled></option>
          <option value="option1">Option 1</option>
          <option value="option2">Option 2</option>
          <option value="option3">Option 3</option>
        </select>
      </div>
    </div>
  );
};

export default Head2Head;
