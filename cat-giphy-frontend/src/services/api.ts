import { CatFact, GifResponse } from '../types/ApiTypes';
//Servicio para consumir el backend creado en .net 
const BASE_URL = 'https://localhost:7016/api'; //Url del backend

export const fetchCatFact = async (): Promise<CatFact> => {
  const res = await fetch(`${BASE_URL}/fact`);
  if (!res.ok) throw new Error('Error al obtener el dato de cat fact');
  return res.json();
};

export const fetchGif = async (query: string): Promise<GifResponse> => {
  const res = await fetch(`${BASE_URL}/gif?query=${query}`);
  if (!res.ok) throw new Error('Error al obtener el gif');
  return res.json();
};
