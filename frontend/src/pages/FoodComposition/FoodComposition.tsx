import { useState } from "react";
import { Footer } from "../../components/Footer/Footer";
import { Header } from "../../components/Header/Header";
import { FoodCompositionContainer, FoodCompositionMain } from "./styles";
import { fetchFoodsComposition } from "../../utils/fetchFoodsCompsition";

function FoodComposition() {
  const [foodCode, setFoodCode] = useState('');

  const handleSearchFood = async () => {
    await fetchFoodsComposition(foodCode)
  }

  return (
    <FoodCompositionContainer>
      <Header />
      <FoodCompositionMain>
        <h3>Digite o código do alimento</h3>
        <input
          type="text"
          placeholder="Digite aqui o código do alimento"
          value={foodCode}
          onChange={(event) => setFoodCode(event.target.value)}
        />
        <button onClick={() => handleSearchFood()}>Procurar</button>
      </FoodCompositionMain>
      <Footer />
    </FoodCompositionContainer>
  )
}

export default FoodComposition;