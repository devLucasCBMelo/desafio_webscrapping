const HOST = import.meta.env.VITE_HOST || 'http://localhost:5032';

export const fetchComponentsDatabase = async () => {
  try {
    const response = await fetch(`${HOST}/api/scraping`);
    const data = await response.json();
    return data;
  } catch (error) {
    console.log("Erro ao preencher as tabelas dos componentes", error);
  }
}