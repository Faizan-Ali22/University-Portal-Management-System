import React from 'react';
import './Skeleton.css';

const Skeleton = ({ variant = 'text', width, height }) => {
  return (
    <div 
      className={`skeleton skeleton-${variant}`} 
      style={{ width, height }}
    />
  );
};

export default Skeleton;
