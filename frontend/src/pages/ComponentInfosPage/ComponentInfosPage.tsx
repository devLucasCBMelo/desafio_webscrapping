import { useParams } from "react-router-dom";
import { ComponentInfosPageContainer } from "./styles";
import { useEffect, useState } from "react";
import { fetchComponentyCode } from "../../utils/fetchComponentByCode";
import { FoodWithComponentTypes } from "../../types/FoodTypes";

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
      <h1>Código do alimento: {foodCode}</h1>
      {componentList && (
        <table>
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
          </tbody>
        </table>
      )}
    </ComponentInfosPageContainer>
  );
}

export default ComponentInfosPage;
