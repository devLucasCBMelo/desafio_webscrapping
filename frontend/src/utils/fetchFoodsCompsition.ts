const HOST = import.meta.env.VITE_HOST || 'http://localhost:5032';

export const fetchFoodsComposition = async (code: string) => {
  try {
    const response = await fetch(`${HOST}/Alimento/componentes/${code}`);
    const data = await response.json();
    console.log("Minha data", data)
    return data;
  } catch (error) {
    console.log("Erro ao buscar alimento", error)
  }

}