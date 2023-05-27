import React from 'react';

const Tabs = () => {
  return (
    <div className="text-sm font-medium text-center text-white border-b border-gray-200 dark:text-gray-400 dark:border-gray-700">
      <ul className="flex flex-wrap -mb-px justify-center">
        <li className="mr-2">
          <a href="#" className="inline-block text-white p-4 border-b-2 border-transparent rounded-t-lg hover:text-gray-600 hover:border-gray-300 dark:hover:text-gray-300">
            Head2Heads</a>
        </li>
        <li className="mr-2">
          <a href="#" className="inline-block text-white p-4 border-b-2 rounded-t-lg active dark:border-blue-500" aria-current="page">
            Championship Orders
          </a>
        </li>
        <li className="mr-2">
          <a href="#" className="inline-block text-white p-4 border-b-2 rounded-t-lg active dark:border-blue-500" aria-current="page">
            Random Prediction
          </a>
        </li>
      </ul>
    </div>
  );
};

export default Tabs;
