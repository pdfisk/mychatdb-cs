import requests
from typing import Any, Dict, Optional
import clr
clr.AddReference("System.Web.Extensions")
from System.Web.Script.Serialization import JavaScriptSerializer


class LmClient:
    """
    A lightweight client for communicating with LLM Studio via HTTP.
    Compatible with structured JSON input/output.
    """

    def __init__(
        self,
        base_url: str = "http://localhost:1234/v1/chat/completions",
        model: str = "qwen/qwen3-coder-30b"
    ):
        self.completions_url = f'{base_url}/chat/completions'
        self.models_url =  f'{base_url}/models'
        self.model = model
        self.serializer = JavaScriptSerializer()

    def get_models(self) -> Optional[Dict[str, Any]]:
        """
        Retrieves the list of available models from the LLM Studio endpoint.
        """
        try:
            response = requests.get(
                self.model_url
            )
            response.raise_for_status()
            return response.json()
        except requests.RequestException as e:
            print(f"[Error] {e}")
            return None

    def send_message(
        self, structured_input: Dict[str, Any]
    ) -> Optional[Dict[str, Any]]:
        """
        Sends structured input data to the LLM Studio endpoint and returns the structured response.
        structured_input should be a dictionary (e.g. {"task": "summarize", "text": "..."}).
        """
        try:
            # Convert structured data to a text message for the LLM
            user_content = self.serializer.Serialize(structured_input, ensure_ascii=False, indent=2)

            payload = {
                "model": self.model,
                "messages": [
                    {
                        "role": "system",
                        "content": "You are a structured data assistant. Reply only in valid JSON.",
                    },
                    {"role": "user", "content": user_content},
                ],
            }

            headers = {"Content-Type": "application/json"}
            response = requests.post(
                self.completions_url, headers=headers, json=payload, timeout=60
            )
            response.raise_for_status()

            data = response.json()

            # Parse JSON response if model outputs structured data
            content = (
                data.get("choices", [{}])[0].get("message", {}).get("content", "{}")
            )
            return self.serializer.DeserializeObject(content)

        except (requests.RequestException, ValueError, 'error') as e:
            print(f"[Error] {e}")
            return None

