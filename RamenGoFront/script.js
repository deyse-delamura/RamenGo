document.addEventListener("DOMContentLoaded", function () {
    const homeBanner = document.getElementById("home-banner");
    const selectionSection = document.getElementById("selection-section");
    const placeOrderButton = document.getElementById("place-order");
    const confirmationSection = document.getElementById("confirmation-section");

    const brothOptionsContainer = document.getElementById("broth-options");
    const proteinOptionsContainer = document.getElementById("protein-options");

    let selectedBroth = null;
    let selectedProtein = null;

    // Map de imagens de acordo com o caldo selecionado
    const brothImages = {
        "1": "assets/images/lamen-salt.png", // ID do Salt
        "2": "assets/images/lamen-soy.png",  // ID do Shoyu
        "3": "assets/images/lamen-miso.png"  // ID do Miso
    };

    homeBanner.addEventListener("click", function () {
        homeBanner.style.display = "none"; // Esconder a capa
        selectionSection.style.display = "block"; // Exibir a seção de seleção
        loadBrothOptions(); // Carregar opções de caldos do backend
        loadProteinOptions(); // Carregar opções de proteínas do backend
    });

    placeOrderButton.addEventListener("click", function () {
        if (selectedBroth && selectedProtein) {
            // Salvar o caldo selecionado no localStorage
            localStorage.setItem("selectedBrothId", selectedBroth);
            realizarPedido(selectedBroth, selectedProtein);
        } else {
            alert("Please select both a broth and a protein.");
        }
    });

    function createCard(item, type) {
        return `
            <div class="card ${type}-card" data-id="${item.id}" data-price="${item.price}" data-active="${item.imageActive}" data-inactive="${item.imageInactive}">
                <img src="${item.imageInactive || 'assets/default-image.png'}" alt="${item.name}" />
                <span id="item-title">${item.name}</span>
                <span id="item-desc">${item.description}</span>
                <span id="item-price">US$ ${item.price}</span>
            </div>
        `;
    }

    function loadBrothOptions() {
        fetch("https://localhost:44317/Caldo") // Substituir com o endpoint real do backend para caldos
            .then(response => response.json())
            .then(data => {
                brothOptionsContainer.innerHTML = data.map(item => createCard(item, "broth")).join("");
                setCardSelection("broth");
            })
            .catch(error => console.error("Erro ao carregar os caldos:", error));
    }

    function loadProteinOptions() {
        fetch("https://localhost:44317/Proteina") // Substituir com o endpoint real do backend para proteínas
            .then(response => response.json())
            .then(data => {
                proteinOptionsContainer.innerHTML = data.map(item => createCard(item, "protein")).join("");
                setCardSelection("protein");
            })
            .catch(error => console.error("Erro ao carregar as proteínas:", error));
    }

    function setCardSelection(type) {
        const cards = document.querySelectorAll(`.${type}-card`);
        cards.forEach(card => {
            card.addEventListener("click", () => {
                cards.forEach(c => {
                    c.classList.remove("selected");
                    c.querySelector("img").src = c.dataset.inactive; // Resetar imagem para inativa
                });
                card.classList.add("selected");
                card.querySelector("img").src = card.dataset.active; // Trocar para a imagem ativa
                if (type === "broth") selectedBroth = card.dataset.id;
                if (type === "protein") selectedProtein = card.dataset.id;
            });
        });
    }

    function realizarPedido(caldoId, proteinaId) {
        fetch("https://localhost:44317/Pedido/realizar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ caldoId: caldoId, proteinaId: proteinaId })
        })
            .then(response => response.json())
            .then(data => {
                mostrarConfirmacao(data.pedidoId, data.descricao);
            })
            .catch(error => console.error("Erro ao realizar pedido:", error));
    }

    function mostrarConfirmacao(pedidoId, descricao) {
        selectionSection.style.display = "none"; // Esconder a seleção
        confirmationSection.style.display = "block"; // Exibir a confirmação

        const orderSummary = document.querySelector("#order-summary h2");
        const orderDescription = document.querySelector("#order-summary .order-description");
        const ramenImage = document.querySelector("#order-summary img");

        // Definir imagem de acordo com o caldo selecionado
        const selectedBrothId = localStorage.getItem("selectedBrothId");
        if (selectedBrothId && brothImages[selectedBrothId]) {
            ramenImage.src = brothImages[selectedBrothId];
        }

        orderSummary.textContent = `Your Order: ${pedidoId}`;
        orderDescription.textContent = descricao;
    }
});