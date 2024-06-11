import React, { useState } from 'react';
import './App.css';

function App() {
  const [prompt, setPrompt] = useState('');
  const [size, setSize] = useState('1024x1024');
  const [style, setStyle] = useState('natural');
  const [quality, setQuality] = useState('standard');
  const [imageUrl, setImageUrl] = useState('');
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = (event) => {
    event.preventDefault();
    setIsLoading(true); 

    const apiUrl = process.env.REACT_APP_API_URL; 
    const data = {
      prompt,
      size,
      style,
      quality
    };

    fetch(apiUrl, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(data => {
      setImageUrl(data); 
    })
    .catch(error => {
      console.error('Error:', error);
    }).finally(() => {
      setIsLoading(false); 
    });;
  };

  return (
    <div className="App">
    <div className="content">
        <div className="form-container">
          <h1>Image Generator</h1>
        <form onSubmit={handleSubmit} className="form">
          <div className="form-group">
            <label htmlFor="prompt">Enter your prompt:</label>
            <textarea
              id="prompt"
              value={prompt}
              onChange={(e) => setPrompt(e.target.value)}
              rows="4"
              required
            ></textarea>
          </div>

          <div className="form-group">
            <label htmlFor="size">Select image size:</label>
            <select id="size" value={size} onChange={(e) => setSize(e.target.value)}>
              <option value="1024x1024">1024x1024</option>
              <option value="1792x1024">1792x1024</option>
              <option value="1024x1792">1024x1792</option>
            </select>
          </div>

          <div className="form-group">
            <label htmlFor="style">Select style:</label>
            <select id="style" value={style} onChange={(e) => setStyle(e.target.value)}>
              <option value="natural">Natural</option>
              <option value="vivid">Vivid</option>              
            </select>
          </div>

          <div className="form-group">
            <label htmlFor="quality">Select quality:</label>
            <select id="quality" value={quality} onChange={(e) => setQuality(e.target.value)}>
              <option value="standard">Standard</option>
              <option value="hd">HD</option>
            </select>
          </div>

          <button type="submit" className="submit-button" disabled={isLoading}> 
           {isLoading ? 'Generating...' : 'Generate Image'}
           </button>
        </form>
        {isLoading && <div className="progress-bar"></div>}
        </div>       
        <div className="image-container">
        <h2>Generated Image:</h2>
          {isLoading ? (
            <div className="placeholder"><div className="loader"></div> </div> 
            
          ) : imageUrl ? (
                          
              <img className="generated-image" src={imageUrl} alt="Generated" />
            
          ) : (
            <div className="placeholder">Please submit a prompt to generate an image.</div> 
          )}
        </div>
      </div>
    </div>
  );
}

export default App;
