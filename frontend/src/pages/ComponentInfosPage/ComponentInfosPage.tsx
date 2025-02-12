import { useParams } from "react-router-dom";
import { ComponentInfosPageContainer, Table } from "./styles";
import { useEffect, useState } from "react";
import { fetchComponentyCode } from "../../utils/fetchComponentByCode";
import { FoodWithComponentTypes } from "../../types/FoodTypes";
import { Header } from "../../components/Header/Header";
import { Footer } from "../../components/Footer/Footer";

function ComponentInfosPage() {
  const { foodCode } = useParams() as { foodCode: string };
  const [componentList, setComponentList] = useState<FoodWithComponentTypes | null>(null);

  useEffect(() => {
    const getComponents = async () => {
      const data = await fetchComponentyCode(foodCode);
      setComponentList(data);
    };

    getComponents();
  }, [foodCode]);

  return (
    <ComponentInfosPageContainer>
      <Header />
      <h1>Código do alimento: {foodCode}</h1>
      {componentList && (
        <Table>
          <thead>
            <tr>
              <td>Componente</td>
              <td>Unidade</td>
              <td>Valor por 100g</td>
              <td>Colher de sopa cheia 45g</td>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Ácidos Graxos Monoinsataturados</td>
              <td>
                {componentList.acidosGraxosMonoinsaturados?.length ? componentList.acidosGraxosMonoinsaturados[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosMonoinsaturados?.length ? componentList.acidosGraxosMonoinsaturados[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosMonoinsaturados?.length ? componentList.acidosGraxosMonoinsaturados[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Ácidos graxos poliinsaturados</td>
              <td>
                {componentList.acidosGraxosPoliinsaturados?.length ? componentList.acidosGraxosPoliinsaturados[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosPoliinsaturados?.length ? componentList.acidosGraxosPoliinsaturados[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosPoliinsaturados?.length ? componentList.acidosGraxosPoliinsaturados[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Ácidos graxos saturados</td>
              <td>
                {componentList.acidosGraxosSaturados?.length ? componentList.acidosGraxosSaturados[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosSaturados?.length ? componentList.acidosGraxosSaturados[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosSaturados?.length ? componentList.acidosGraxosSaturados[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Ácidos graxos trans</td>
              <td>
                {componentList.acidosGraxosTrans?.length ? componentList.acidosGraxosTrans[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosTrans?.length ? componentList.acidosGraxosTrans[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.acidosGraxosTrans?.length ? componentList.acidosGraxosTrans[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Acúcar de adição</td>
              <td>
                {componentList.acucarDeAdicao?.length ? componentList.acucarDeAdicao[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.acucarDeAdicao?.length ? componentList.acucarDeAdicao[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.acucarDeAdicao?.length ? componentList.acucarDeAdicao[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Álcool</td>
              <td>
                {componentList.alcool?.length ? componentList.alcool[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.alcool?.length ? componentList.alcool[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.alcool?.length ? componentList.alcool[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Cálcios</td>
              <td>
                {componentList.calcios?.length ? componentList.calcios[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.calcios?.length ? componentList.calcios[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.calcios?.length ? componentList.calcios[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Carboidrato disponível</td>
              <td>
                {componentList.carboidratoDisponivel?.length ? componentList.carboidratoDisponivel[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.carboidratoDisponivel?.length ? componentList.carboidratoDisponivel[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.carboidratoDisponivel?.length ? componentList.carboidratoDisponivel[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Carboirato total</td>
              <td>
                {componentList.carboidratoTotal?.length ? componentList.carboidratoTotal[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.carboidratoTotal?.length ? componentList.carboidratoTotal[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.carboidratoTotal?.length ? componentList.carboidratoTotal[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Cinzas</td>
              <td>
                {componentList.cinzas?.length ? componentList.cinzas[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.cinzas?.length ? componentList.cinzas[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.cinzas?.length ? componentList.cinzas[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Cobre</td>
              <td>
                {componentList.cobre?.length ? componentList.cobre[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.cobre?.length ? componentList.cobre[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.cobre?.length ? componentList.cobre[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Colesterol</td>
              <td>
                {componentList.colesterol?.length ? componentList.colesterol[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.colesterol?.length ? componentList.colesterol[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.colesterol?.length ? componentList.colesterol[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Energia</td>
              <td>
                {componentList.energiaKcal?.length ? componentList.energiaKcal[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.energiaKcal?.length ? componentList.energiaKcal[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.energiaKcal?.length ? componentList.energiaKcal[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Energia</td>
              <td>
                {componentList.energiaKJs?.length ? componentList.energiaKJs[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.energiaKJs?.length ? componentList.energiaKJs[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.energiaKJs?.length ? componentList.energiaKJs[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Equivalente de folato</td>
              <td>
                {componentList.equivalenteDeFolato?.length ? componentList.equivalenteDeFolato[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.equivalenteDeFolato?.length ? componentList.equivalenteDeFolato[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.equivalenteDeFolato?.length ? componentList.equivalenteDeFolato[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Ferro</td>
              <td>
                {componentList.ferro?.length ? componentList.ferro[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.ferro?.length ? componentList.ferro[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.ferro?.length ? componentList.ferro[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Fibra alimentar</td>
              <td>
                {componentList.fibraAlimentar?.length ? componentList.fibraAlimentar[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.fibraAlimentar?.length ? componentList.fibraAlimentar[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.fibraAlimentar?.length ? componentList.fibraAlimentar[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Fósforo</td>
              <td>
                {componentList.fosforo?.length ? componentList.fosforo[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.fosforo?.length ? componentList.fosforo[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.fosforo?.length ? componentList.fosforo[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Lipídios</td>
              <td>
                {componentList.lipidios?.length ? componentList.lipidios[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.lipidios?.length ? componentList.lipidios[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.lipidios?.length ? componentList.lipidios[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Magnésio</td>
              <td>
                {componentList.magnesio?.length ? componentList.magnesio[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.magnesio?.length ? componentList.magnesio[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.magnesio?.length ? componentList.magnesio[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Manganês</td>
              <td>
                {componentList.manganes?.length ? componentList.manganes[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.manganes?.length ? componentList.manganes[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.manganes?.length ? componentList.manganes[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Niacina</td>
              <td>
                {componentList.niacina?.length ? componentList.niacina[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.niacina?.length ? componentList.niacina[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.niacina?.length ? componentList.niacina[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Potássio</td>
              <td>
                {componentList.potassio?.length ? componentList.potassio[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.potassio?.length ? componentList.potassio[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.potassio?.length ? componentList.potassio[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Proteína</td>
              <td>
                {componentList.proteina?.length ? componentList.proteina[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.proteina?.length ? componentList.proteina[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.proteina?.length ? componentList.proteina[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Riboflavina</td>
              <td>
                {componentList.riboflavina?.length ? componentList.riboflavina[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.riboflavina?.length ? componentList.riboflavina[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.riboflavina?.length ? componentList.riboflavina[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Sal de adição</td>
              <td>
                {componentList.salDeAdicao?.length ? componentList.salDeAdicao[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.salDeAdicao?.length ? componentList.salDeAdicao[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.salDeAdicao?.length ? componentList.salDeAdicao[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Selênio</td>
              <td>
                {componentList.selenio?.length ? componentList.selenio[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.selenio?.length ? componentList.selenio[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.selenio?.length ? componentList.selenio[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Sódio</td>
              <td>
                {componentList.sodio?.length ? componentList.sodio[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.sodio?.length ? componentList.sodio[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.sodio?.length ? componentList.sodio[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Tiamina</td>
              <td>
                {componentList.tiamina?.length ? componentList.tiamina[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.tiamina?.length ? componentList.tiamina[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.tiamina?.length ? componentList.tiamina[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Umidade</td>
              <td>
                {componentList.umidade?.length ? componentList.umidade[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.umidade?.length ? componentList.umidade[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.umidade?.length ? componentList.umidade[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Vitamina A (RAE)</td>
              <td>
                {componentList.vitaminaARAE?.length ? componentList.vitaminaARAE[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.vitaminaARAE?.length ? componentList.vitaminaARAE[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.vitaminaARAE?.length ? componentList.vitaminaARAE[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Vitamina A (RE)</td>
              <td>
                {componentList.vitaminaARE?.length ? componentList.vitaminaARE[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.vitaminaARE?.length ? componentList.vitaminaARE[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.vitaminaARE?.length ? componentList.vitaminaARE[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Vitamina B12</td>
              <td>
                {componentList.vitaminaB12?.length ? componentList.vitaminaB12[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.vitaminaB12?.length ? componentList.vitaminaB12[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.vitaminaB12?.length ? componentList.vitaminaB12[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Vitamina B6</td>
              <td>
                {componentList.vitaminaB6?.length ? componentList.vitaminaB6[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.vitaminaB6?.length ? componentList.vitaminaB6[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.vitaminaB6?.length ? componentList.vitaminaB6[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Vitamina C</td>
              <td>
                {componentList.vitaminaC?.length ? componentList.vitaminaC[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.vitaminaC?.length ? componentList.vitaminaC[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.vitaminaC?.length ? componentList.vitaminaC[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Vitamina D</td>
              <td>
                {componentList.vitaminaD?.length ? componentList.vitaminaD[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.vitaminaD?.length ? componentList.vitaminaD[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.vitaminaD?.length ? componentList.vitaminaD[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Alfa-tocoferol (Vitamina E)</td>
              <td>
                {componentList.vitaminaE?.length ? componentList.vitaminaE[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.vitaminaE?.length ? componentList.vitaminaE[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.vitaminaE?.length ? componentList.vitaminaE[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>

            <tr>
              <td>Zinco</td>
              <td>
                {componentList.zinco?.length ? componentList.zinco[0].unidades : "N/A"}
              </td>
              <td>
                {componentList.zinco?.length ? componentList.zinco[0].valorPor100g : "N/A"}
              </td>
              <td>
                {componentList.zinco?.length ? componentList.zinco[0].colherSopaCheia45g : "N/A"}
              </td>
            </tr>
          </tbody>
        </Table>
      )}
      <Footer />
    </ComponentInfosPageContainer>
  );
}

export default ComponentInfosPage;
