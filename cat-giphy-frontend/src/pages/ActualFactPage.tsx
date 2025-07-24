import React, { useEffect, useState } from 'react';
import { fetchCatFact, fetchGif } from '../services/api';
import { GifResponse } from '../types/ApiTypes';

const ActualFactPage: React.FC = () => {
  const [fact, setFact] = useState<string>('');
  const [gifUrl, setGifUrl] = useState<string>('');
  const [query, setQuery] = useState<string>('');
  const [loading, setLoading] = useState<boolean>(true);

  // Inicialmente obtiene el fact y el gif
  useEffect(() => {
    const loadData = async () => {
      setLoading(true);
      try {
        const cat = await fetchCatFact();
        setFact(cat.fact);
        const words = cat.fact.split(' ').slice(0, 3).join(' ');
        setQuery(words);
        const gif = await fetchGif(words);
        setGifUrl(gif.gif);
      } catch (error) {
        console.error(error);
      } finally {
        setLoading(false);
      }
    };

    loadData();
  }, []);

  // Solo refresca el gif, mantiene el fact
  const refreshGif = async () => {
    try {
    
      const gif = await fetchGif(query);
    
      setGifUrl(gif.gif);
    } catch (error) {
      console.error(error);
    }
  };

  if (loading) return <p>Cargando...</p>;

  return (
    <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'center', gap: '2rem' }}>
      <img src={gifUrl} alt="GIF" style={{ maxWidth: '300px', borderRadius: '10px' }} />
      <div>
        <p style={{ fontSize: '1.2rem', maxWidth: '400px' }}>{fact}</p>
        <button
          onClick={refreshGif}
          style={{
            marginTop: '1rem',
            padding: '10px 20px',
            backgroundColor: '#007bff',
            color: 'white',
            border: 'none',
            borderRadius: '5px',
            cursor: 'pointer',
          }}
        >
          Refrescar GIF
        </button>
      </div>
    </div>
  );
};

export default ActualFactPage;
