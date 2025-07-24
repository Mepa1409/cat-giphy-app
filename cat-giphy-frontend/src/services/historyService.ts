export interface HistoryRecord {
  date: string;
  fact: string;
  queryWords: string;
  gifUrl: string;
}
//se hace consumo de la informacion del back para posteriormente mostrarla en el front
export async function fetchHistory(): Promise<HistoryRecord[]> {
  const response = await fetch("https://localhost:7016/api/history");

  if (!response.ok) {
    throw new Error("Error al obtener el historial");
  }

  return await response.json();
}
